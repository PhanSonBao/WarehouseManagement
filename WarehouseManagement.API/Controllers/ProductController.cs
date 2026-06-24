using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.Features.Product.Commands.Create;
using WarehouseManagement.Application.Features.Product.Queries.GetById;

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

        return Ok();
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

    // POST api/products
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand productCommand)
    {
        // Gọi _sender.Send(productCommand)
        var publicId = await sender.Send(productCommand);

        // Trả về CreatedAtAction trỏ tới GetById, kèm id vừa tạo
        return CreatedAtAction(nameof(GetById), new { publicId }, new { publicId });
    }
}