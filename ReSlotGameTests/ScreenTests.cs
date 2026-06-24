namespace ReSlotGameTests;
using Domain;

public class ScreenTests
{
    [Fact]
    public void GetStopIndexs_ShouldReturnCorrectIndexes()
    {
        var wheels = new List<List<string>>()
        {
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
        };
        var screen = new Screen(wheels, new SpecifyNumberGenerator([2, 0 ,4 ,1 ,3]));
        Assert.Equal(new List<int>() {2, 0, 4, 1, 3}, screen.GetStopIndexs());
    }
}