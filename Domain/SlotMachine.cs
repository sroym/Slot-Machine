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

    private int GetLines(List<List<string>> screenWheels)
    {
        int sumOfSameLines = 0;
        for (int i = 0; i < screenWheels[0].Count; i++)
        {
            var hash = new HashSet<string>();
            foreach (var wheel in screenWheels)
            {
                hash.Add(wheel[i]);
            }

            if (hash.Count == 1)
                sumOfSameLines++;
        }
        
        return sumOfSameLines;
    }

    public List<List<string>> GetScreen()
    {
        return _currentScreen.Wheels;
    }
    public List<int> GetStopIndexes()
    {
        return _currentScreen.GetStopIndexes();
    }
}
