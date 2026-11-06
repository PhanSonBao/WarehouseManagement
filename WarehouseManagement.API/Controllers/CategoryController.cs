using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.Features.Category.Create;
using WarehouseManagement.Application.Features.Category.GetById;

namespace WarehouseManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ISender sender) : ControllerBase
{
    // Get Category detail
    [HttpGet("{publicId}")]
    public async Task<IActionResult> GetById(string publicId)
    {
        // Create GetCategoryByIdQuery
        var query = new GetCategoryByIdQuery(publicId);
        var result = await sender.Send(query);

        return Ok(result);
    }
    
    // Create Category
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        var publicId = await sender.Send(command);
        return CreatedAtAction(nameof(GetById), new { publicId }, new { publicId });
    }
}