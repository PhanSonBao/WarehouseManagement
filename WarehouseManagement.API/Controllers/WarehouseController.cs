using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.Features.Warehouse.Create;
using WarehouseManagement.Application.Features.Warehouse.GetById;

namespace WarehouseManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController(ISender sender) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var query = new GetWarehouseByIdQuery(id);
        var result = await sender.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWarehouseCommand command)
    {
        var publicId = await sender.Send(command);
        return CreatedAtAction(nameof(GetById), new {publicId}, new { publicId });
    }
}