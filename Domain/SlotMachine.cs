namespace Domain;

public class SlotMachine
{
    private readonly List<List<string>> _wheels;

    public SlotMachine(List<List<string>> wheels)
    {
        _wheels = wheels;
    }

    public int Calculate(int bet)
    {
        var paytable = new PayTable();
        int lines = GetLines();
        return paytable.GetOdd(lines) * bet;
    }

    private int GetLines()
    {
        int sumOfSameLines = 0;
        for (int i = 0; i < 3; i++)
        {
            var hash = new HashSet<string>();
            foreach (var wheel in _wheels)
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
}

public class PayTable
{
    public int GetOdd(int lines)
    {
        return _oddTable.TryGetValue(lines, out var odd) ? odd : 0;
    }

    private readonly Dictionary<int, int> _oddTable = new()
    {
        { 0, 0 },
        { 1, 10 },
        { 2, 40 },
        { 3, 100 },
    };
}

