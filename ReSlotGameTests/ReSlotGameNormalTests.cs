using Domain.Gateway;

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
        },new SpecifyNumberGenerator([0, 0 ,0, 0, 0]), new PayTable());
        
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
            new List<string>(){"9", "Q", "10", "9", "A","J"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
        },new SpecifyNumberGenerator([0, 0 ,0, 0, 0]), new PayTable());
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
            new List<string>(){"A", "Q", "K", "10", "A","9"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
        },new SpecifyNumberGenerator ([0, 0 ,0 ,0 ,0]), new PayTable());
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
        },new SpecifyNumberGenerator ([0, 0, 0, 0, 0]), new PayTable());
        var user = User.FromToken("token", new FakeUserRepository());
        user.Spin(slot, 10);
        Assert.Equal(1990, user.GetMoney());

    }
    
    
    [Fact]
    public void should_throw_when_not_amount()
    {
        var slot = new SlotMachine(new List<List<string>>()
        {
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"K", "J", "Q", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
        },new SpecifyNumberGenerator ([0, 0, 0, 0, 0]), new PayTable());
        var user = User.FromToken("token", new FakeUserRepository());
        Assert.ThrowsAny<Exception>(() => user.Spin(slot,10000));
    }

    [Fact]
    public void AllIn()
    {
        var slot = new SlotMachine(new List<List<string>>()
        {
            
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"K", "J", "Q", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
            new List<string>(){"J", "Q", "K", "9", "10","A"},
        },new SpecifyNumberGenerator([0, 0, 0, 0, 0]),new PayTable());
        var user = User.FromToken("token", new FakeUserRepository());
        user.Spin(slot, 1000);
        Assert.Equal(0, user.GetMoney());
    }
    [Fact]
    public void should_throw_when_bet_is_zero()
    {
        var user = new User("Roy");
        user.SetBet(1000);
        var slot = new SlotMachine(
            new List<List<string>>() {
                new List<string>() { "7", "7", "7" },
                new List<string>() { "7", "7", "7" },
                new List<string>() { "7", "7", "7" },
                new List<string>() { "7", "7", "7" },
                new List<string>() { "7", "7", "7" },
            },new SpecifyNumberGenerator([0, 0, 0, 0, 0]), new PayTable());
        Assert.ThrowsAny<Exception>(() => user.Spin(slot, 0));
    }
    [Fact]
    public void should_throw_when_bet_is_negative()
    {
        var user = new User("Roy");
        user.SetBet(1000);
        var slot = new SlotMachine(
            new List<List<string>>() {
                new List<string>() { "7", "7", "7" },
                new List<string>() { "7", "7", "7" },
                new List<string>() { "7", "7", "7" },
                new List<string>() { "7", "7", "7" },
                new List<string>() { "7", "7", "7" },
            },new SpecifyNumberGenerator([0, 0, 0, 0, 0]), new PayTable());
        Assert.ThrowsAny<Exception>(() => user.Spin(slot, -10));
    }
}

public class FakeUserRepository : UserRepositoryGateway
{
    public User FindFromToken(string token)
    {
        var user = new User("Roy");
        user.SetBet(1000);
        return user;
    }
    public User FindFromUsername(string username)
    {
        var user = new User("Roy");
        user.SetBet(1000);
        return user;
    }
}