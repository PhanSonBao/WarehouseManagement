using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.Features.Warehouse.Create;

namespace WarehouseManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController(ISender sender) : ControllerBase
{
    // [HttpGet]
    // public async Task<IActionResult> GetById(Guid publicId)
    // {
    //     var query = new GetById(publicId);
    // }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWarehouseCommand command)
    {
        var publicId = await sender.Send(command);
        return CreatedAtAction(nameof(GetById), new {publicId}, new { publicId });
    }
}