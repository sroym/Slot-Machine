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
        return userRepo.FindFromUsername(token);
    }

    public void SetBet(int money)
    {
        _money = money;
    }

    public void Spin(ISlotMachine slot, int bet)
    {
        if(bet <=0)throw new Exception("投點錢好嗎?");
        if (_money < bet) throw new Exception("沒錢還想玩?");
        _money -= bet;
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