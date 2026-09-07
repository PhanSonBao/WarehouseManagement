using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.Features.Warehouse.Create;
using WarehouseManagement.Application.Features.Warehouse.GetById;

namespace WarehouseManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController(ISender sender) : ControllerBase
{
    [HttpGet("{publicId:guid}")]
    public async Task<IActionResult> GetById(Guid publicId)
    {
        var query = new GetWarehouseByIdQuery(publicId);
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