using Domain.Gateway;

namespace Domain;

public class User
{
    private string _name;
    private int _money;

    public User(string name)
    {
        _name = name;
    }

    public static User FromToken(string token, UserRepositoryGateway userRepo)
    {
        return userRepo.FindFromToken(token);
    }

    public void SetBet(int money)
    {
        _money = money;
    }

    public void Spin(SlotMachine slot, int bet)
    {
        _money -= bet;
        if (_money < 0) throw new Exception("No Money Get Out");
        var win = slot.Calculate(bet);
        _money += win;
    }

    public int GetMoney()
    {
        return _money;
    }

    public String GetName()
    {
        return _name;
    }
}