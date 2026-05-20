namespace ReSlotGameTests;

using Domain;

public class ReSlotGameNormalTests
{
    [Fact]
    public void Loss()
    {
        var slot = new SlotMachine(new List<List<string>>()
        {
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"K", "J", "Q", "10", "A","9"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
        },new RandomNumberGenerator(6), new PayTable());
        
        var win = slot.Calculate(10);
        Assert.Equal(0, win);
    }
    [Fact]
    public void HitOneLine()
    {
        var slot = new SlotMachine(new List<List<string>>()
        {
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "9", "Q", "10", "A","K"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
        },new RandomNumberGenerator(6), new PayTable());
        var win = slot.Calculate(10);
        Assert.Equal(100, win);
    }
    [Fact]
    public void HitTwoLines()
    {
        var slot = new SlotMachine(new List<List<string>>()
        {
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "10", "K", "A","9"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
        },new RandomNumberGenerator(6), new PayTable());
        var win = slot.Calculate(10);
        Assert.Equal(400, win);
    } 
    [Fact]
    public void HitThreeLines()
    {
        var slot = new SlotMachine(new List<List<string>>()
        {
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "10", "A","9"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
        },new RandomNumberGenerator(6), new PayTable());
        var win = slot.Calculate(10);
        Assert.Equal(1000, win);
    }
}