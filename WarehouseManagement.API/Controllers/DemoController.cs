using Microsoft.AspNetCore.Mvc;

namespace WarehouseManagement.API.Controllers;

public class DemoController(IConfiguration configuration) : ControllerBase
{
    [Route("api/demo")]
    [HttpGet]
    public async Task<IActionResult> Demo()
    {
        return Ok(configuration.GetConnectionString("DefaultConnection") ?? string.Empty);
    }
}