using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.Features.Product.Commands.Create;
using WarehouseManagement.Application.Features.Product.Queries.GetById;

namespace WarehouseManagement.API.Controllers;

[ApiController]
[Route(("api/[controller]"))]
public class ProductController : ControllerBase
{
    // Inject ISender (MediatR) qua constructor
    // Không inject Handler trực tiếp — luôn đi qua ISender
    private readonly ISender _sender;

    public ProductController(ISender sender) => _sender = sender;

    // GET api/products/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(int id)
    {
        // Tạo GetByIdQuery(id)
        var query = new GetByIdQuery(id);

        // Gọi _sender.Send(query)
        var result = await _sender.Send(query);

        // If null -> Handler throw NotFoudnException -> Middleware return 404
        // If not null: return Ok(result)
        return Ok(result);
    }

    // POST api/products
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand productCommand)
    {
        // Gọi _sender.Send(productCommand)
        var id = await _sender.Send(productCommand);

        // Trả về CreatedAtAction trỏ tới GetById, kèm id vừa tạo
        // Gợi ý: return CreatedAtAction(nameof(GetById), new { id }, new { id })
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }
}