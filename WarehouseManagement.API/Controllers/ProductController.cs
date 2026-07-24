using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.Features.Product.Create;
using WarehouseManagement.Application.Features.Product.Delete;
using WarehouseManagement.Application.Features.Product.GetAll;
using WarehouseManagement.Application.Features.Product.GetById;
using WarehouseManagement.Application.Features.Product.Update;

namespace WarehouseManagement.API.Controllers;

[ApiController]
[Route(("api/[controller]"))]
// Inject ISender (MediatR) qua constructor
public class ProductController(ISender sender) : ControllerBase
{
    // GET api/products
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllQuery();
        var result = await sender.Send(query);

        return Ok(result);
    }

    // GET api/products/{id}
    [HttpGet("{publicId:guid}")]
    public async Task<IActionResult> GetById(Guid publicId)
    {
        // Tạo GetByIdQuery(id)
        var query = new GetByIdQuery(publicId);

        // Gọi _sender.Send(query)
        var result = await sender.Send(query);

        // If null -> Handler throw NotFoudnException -> Middleware return 404
        // If not null: return Ok(result)
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand productCommand)
    {
        // Gọi _sender.Send(productCommand)
        var publicId = await sender.Send(productCommand);

        // Trả về CreatedAtAction trỏ tới GetById, kèm id vừa tạo
        return CreatedAtAction(nameof(GetById), new { publicId }, new { publicId });
    }

    // PUT api/products/{publicId}
    [HttpPut("{publicId:guid}")]
    public async Task<IActionResult> Update(Guid publicId, [FromBody] UpdateProductCommand productCommand)
    {
        var command = productCommand with { PublicId = publicId };
        await sender.Send(command);
        
        return NoContent();
    }
    
    // DELETE api/products/{publicId}
    [HttpPatch]
    public async Task<IActionResult> Delete(int id, string name)
    {
        var command = new DeleteProductCommand(id, name);
        await sender.Send(command);
        
        return NoContent();
    }
}