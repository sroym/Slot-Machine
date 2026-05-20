namespace ReSlotGameTests;

using Domain;

public class ReSlotGameNormalTests
{
    [Fact]
    public void Loss()
    {
        var slot = new ReSlotMachine(new List<List<string>>()
        {
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"K", "J", "Q", "10", "A","9"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
        });
        var win = slot.Calculate(10);
        Assert.Equal(0, win);
    }
}