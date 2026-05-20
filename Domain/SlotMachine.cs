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

    public int Calculate(int bet)
    {
        var  _currentscreen= new Screen(_wheels, _numberGenerator);
        var odd = _payTable.GetOdd(GetLines(_currentscreen._wheels));//
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
                hash.Add(wheel[i]);
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
        return _currentScreen._wheels;
    }
}



