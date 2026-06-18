using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.Features.Category.Commands.Create;
using WarehouseManagement.Application.Features.Category.Queries.GetById;

namespace WarehouseManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ISender sender) : ControllerBase
{
    // GET /api/categories/{id}
    [HttpGet("{publicId:guid}")]
    public async Task<IActionResult> GetById(Guid publicId)
    {
        // Create GetByIdQuery
        var query = new GetByIdQuery(publicId);
        var result = await sender.Send(query);

        return Ok(result);
    }
    
    // POST /api/categories
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        var id = await sender.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }
}