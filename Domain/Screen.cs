namespace Domain;

public class Screen
{
     public List<List<string>> Wheels { get; private set; }
     public List<int> StopIndexes { get; private set; }
     private  readonly INumberGenerator _numberGenerator;

    public Screen(List<List<string>> wheels, INumberGenerator numberGenerator)
    {
        _numberGenerator = numberGenerator;
        StopIndexes = new List<int>();
        Wheels = GetScreen(wheels);
    }

    private List<List<string>> GetScreen(List<List<string>> wheels)
    {
        var screen =  new List<List<string>>();
        for (int i = 0; i < wheels.Count; i++)
        {
            int nextPosition = _numberGenerator.Generate();
            StopIndexes.Add(nextPosition);
            var column = wheels[i].Concat(wheels[i])
                .ToList()
                .GetRange(nextPosition, 3);
            screen.Add(column);
        }

        return screen;
    }

    public List<int> GetStopIndexes()
    {
        return StopIndexes;
    }

}