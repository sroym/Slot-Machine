using Domain.Gateway;

namespace Domain;

public class SlotMachine
{
    private readonly List<List<string>> _wheels;
    private readonly PayTable _payTable;
    private readonly INumberGenerator _numberGenerator;
    private Screen _currentScreen;
    
    public SlotMachine(List<List<string>> wheels, INumberGenerator numberGenerator,  PayTable payTable)
    {
        if(wheels.Count == 0) throw new ArgumentNullException(nameof(wheels));
        _wheels = wheels;
        _payTable = payTable;
        _numberGenerator = numberGenerator;
    }

    // 靜態工廠
    public static SlotMachine Restore(
        string token,
        User user,
        WheelsRepositoryGateway wheelsRepository,
        INumberGenerator numberGenerator,
        PayTable payTable)
    {
        var wheels = wheelsRepository.GetFromUser(user);
        return new SlotMachine(wheels, numberGenerator, payTable);
    }

    public int Calculate(int bet)
    {
        _currentScreen= new Screen(_wheels, _numberGenerator);
        var odd = _payTable.GetOdd(GetLines(_currentScreen.Wheels));
        return odd * bet;
    }

    private int GetLines(List<List<string>> screen)
    {
        int sumOfSameLines = 0;
        for (int i = 0; i < 3; i++)
        {
            var hash = new HashSet<string>();
            foreach (var wheel in screen)
            {
                hash.Add(wheel[i+1]);
            }

            if (hash.Count == 1)
            {
                sumOfSameLines++;
            }
        }
        
        return sumOfSameLines;
    }

    public List<List<string>> GetScreen()
    {
        return _currentScreen.Wheels;
    }
}



class Player
{
    public string Name;
    public int Level;
    public string Role;

    private Player(string name, int level, string role)
    {
        Name = name;
        Level = level;
        Role = role;
    }

    public static Player CreateWarrior(string name)
    {
        if (name == "") throw new Exception("name cannot be empty");
        return new Player(name, 1, "Warrior");
    }
    
}