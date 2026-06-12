using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.Features.Category.Commands.Create;

namespace WarehouseManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ISender _sender;

    public CategoryController(ISender sender)
    {
        _sender = sender;
    }
    
    // POST /api/categories
    [HttpPost]
    public Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        return null;
    }
}