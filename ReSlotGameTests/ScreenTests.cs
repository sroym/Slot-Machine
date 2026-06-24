namespace ReSlotGameTests;
using Domain;

public class ScreenTests
{
    [Fact]
    public void GetStopIndexs_ShouldReturnCorrectIndexes()
    {
        var wheels = new List<List<string>>()
        {
            new List<string>() { "J", "$", "K", "$", "Q", "$" },
            new List<string>() { "J", "$", "K", "$", "Q", "$" },
            new List<string>() { "J", "$", "K", "$", "Q", "$" },
            new List<string>() { "J", "$", "K", "$", "Q", "$" },
            new List<string>() { "J", "$", "K", "$", "Q", "$" },
        };
        
        var screen = new Screen(wheels, new SpecifyNumberGenerator([2, 0 ,4 ,1 ,3]));
        
        Assert.Equal(new List<int>() {2, 0, 4, 1, 3}, screen.GetStopIndexes());
    }
    [Fact]
    public void GetScreen_ShouldReturnCorrectSymbols()
    {
        var wheels = new List<List<string>>()
        {
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
        };
        
        var screen = new Screen(wheels, new SpecifyNumberGenerator([2, 0, 4, 1, 3]));
        
        Assert.Equal(new List<string>() { "K", "$", "$" }, screen.Wheels[0]);
        Assert.Equal(new List<string>() { "J", "Q", "K" }, screen.Wheels[1]);
        Assert.Equal(new List<string>() { "$", "$", "J" }, screen.Wheels[2]);
        Assert.Equal(new List<string>() { "Q", "K", "$" }, screen.Wheels[3]);
        Assert.Equal(new List<string>() { "$", "$", "$" }, screen.Wheels[4]);
    }
    
}