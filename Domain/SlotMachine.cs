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
        int lines = GetLines();
        return lines * bet;
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