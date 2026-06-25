using Application.Services.Spin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReDomainAPI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SlotController : ControllerBase
{
    private readonly ISpinService _spinService;

    public SlotController(ISpinService spinService)
    {
        _spinService = spinService;
    }

    [HttpPost]
    public IActionResult Spin(int bet)
    {
        try
        {
            var result = _spinService.Spin(bet);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}