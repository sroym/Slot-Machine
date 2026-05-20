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
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"A", "Q", "10", "9", "K","J"},
            new List<string>(){"J", "9", "Q", "10", "A","K"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"K", "Q", "9", "J", "10","A"},
        },new RandomNumberGenerator(6), new PayTable());
        var win = slot.Calculate(bet);
        return new SpinResult()
        {
            WinMoney = win,
            Screen = slot.GetScreen()
        };
    }
}

public class SpinResult
{
    public int WinMoney { get; set; }
    public List<List<string>> Screen { get; set; }
}