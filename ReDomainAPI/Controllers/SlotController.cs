namespace ReDomainAPI.Controllers;
using Domain;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SlotController
{
    private readonly SlotMachine _slotMachine;

    public SlotController(SlotMachine slotMachine)
    {
        _slotMachine = slotMachine;
    }
    [HttpPost]
    public SpinResult Spin(int bet)
    {
       
        var win = _slotMachine.Calculate(bet);
        return new SpinResult()
        {
            WinMoney = win,
            Screen = _slotMachine.GetScreen()
        };
    }
}

public record struct SpinResult(int WinMoney, List<List<string>> Screen, int InitialAmount);