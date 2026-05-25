namespace ReDomainAPI.Controllers;
using Domain;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SlotController
{
    [HttpPost]
    public SpinResult Spin(int bet)
    {
        var slot = new SlotMachine(new List<List<string>>()
        {
            new List<string>(){"J", "Q", "K", "$", "$","$"},
            new List<string>(){"J", "Q", "K", "$", "$","$"},
            new List<string>(){"J", "Q", "K", "$", "$","$"},
            new List<string>(){"J", "Q", "K", "$", "$","$"},
            new List<string>(){"J", "Q", "K", "$", "$","$"},
        },new RandomNumberGenerator(6), new PayTable());
        var win = slot.Calculate(bet);
        return new SpinResult()
        {
            WinMoney = win,
            Screen = slot.GetScreen()
        };
    }
}

public record struct SpinResult(int WinMoney, List<List<string>> Screen);