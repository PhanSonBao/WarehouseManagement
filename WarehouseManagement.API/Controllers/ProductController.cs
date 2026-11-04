using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.DTO;
using WarehouseManagement.Application.Features.Product.Create;
using WarehouseManagement.Application.Features.Product.Delete;
using WarehouseManagement.Application.Features.Product.GetById;
using WarehouseManagement.Application.Features.Product.GetList;
using WarehouseManagement.Application.Features.Product.Update;
using Microsoft.Extensions.Caching.Distributed;

namespace WarehouseManagement.API.Controllers;

[ApiController]
[Route(("api/[controller]"))]
// Inject ISender (MediatR) via constructor
public class ProductController(ISender sender, IDistributedCache cache, ILogger<ProductController> logger) : ControllerBase
{
    // Create Unique Key for every Product
    private static string GetCacheKey(Guid publicId) => $"product:by-id:{publicId:N}";
    
    // Get list product
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var query = new GetProductListQuery();
        var result = await sender.Send(query);

        return Ok(result);
    }

    // Get product detail
    [HttpGet("{publicId:guid}")]
    public async Task<IActionResult> GetById(Guid publicId, CancellationToken ct)
    {
        // Redis key
        var cacheKey = GetCacheKey(publicId);
        var cachedJson = await cache.GetStringAsync(cacheKey);
        
        // Cache HIT
        if (cachedJson is not null)
        {
            var cachedProduct = JsonSerializer.Deserialize<ProductDto>(cachedJson);
            if (cachedProduct is not null)
            {
                logger.LogInformation("CACHE HIT: {Key}", cacheKey);
                return Ok(cachedProduct);
            }
        }
        // Cache MISS
        logger.LogInformation("CACHE MISS: {Key}", cacheKey);
        
        var query = new GetProductByIdQuery(publicId); // Tạo GetCategoryByIdQuery(id)
        var result = await sender.Send(query); // Gọi _sender.Send(query)
        var json = JsonSerializer.Serialize(result);
        
        // Save Redis TTL 2 min
        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
        };
        await cache.SetStringAsync(cacheKey, json, options, ct);
        
        return Ok(result);
    }

    // Crete new product
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand create)
    {
        // Gọi _sender.Send(productCommand)
        var publicId = await sender.Send(create);

        // Trả về CreatedAtAction trỏ tới GetById, kèm id vừa tạo
        return CreatedAtAction(nameof(GetById), new { publicId }, new { publicId });
    }

    // Update product
    [HttpPut("{publicId:guid}")]
    public async Task<IActionResult> Update(Guid publicId, [FromBody] UpdateProductCommand update)
    {
        var command = update with { PublicId = publicId };
        await sender.Send(command);
        
        return NoContent();
    }
    
    // Deactivate product
    [HttpPost("{publicId:guid}/deactivate")]
    public async Task<IActionResult> Delete(Guid publicId)
    {
        var command = new DeleteProductCommand(publicId);
        await sender.Send(command);
        
        return NoContent();
    }
}