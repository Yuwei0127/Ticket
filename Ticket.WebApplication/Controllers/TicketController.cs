using Microsoft.AspNetCore.Mvc;

namespace Ticket.Application.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    [HttpGet("test")]
    public async Task<IActionResult> TestAsync()
    {

        return Ok();
    }
}