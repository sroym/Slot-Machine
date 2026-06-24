using Microsoft.AspNetCore.Authorization;

namespace ReDomainAPI.Controllers;
using Domain;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SlotController: ControllerBase
{
    private readonly SlotMachine _slotMachine;
    private readonly User _user;

    public SlotController(SlotMachine slotMachine, User user)
    {
        _slotMachine = slotMachine;
        _user = user;
    }
    
    [HttpPost]
    public ActionResult<SpinResult> Spin(int bet)
    {
        try
        {
            _user.Spin(_slotMachine, bet);

            return Ok(new SpinResult()
            {
                userMoney = _user.GetMoney(),
                Screen = _slotMachine.GetScreen(),
                StopIndexes = _slotMachine.GetStopIndexes(),
            });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}

public record struct SpinResult(int userMoney, List<List<string>> Screen, List<int>StopIndexes);