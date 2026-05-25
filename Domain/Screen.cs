namespace Domain;

public class Screen
{
     public List<List<string>> Wheels { get; private set; }
     private  readonly INumberGenerator _numberGenerator;

    public Screen(List<List<string>> wheels, INumberGenerator numberGenerator)
    {
        _numberGenerator = numberGenerator;
        Wheels = GetScreen(wheels);
    }

    private List<List<string>> GetScreen(List<List<string>> wheels)
    {
        var screen =  new List<List<string>>();
        for (int i = 0; i < wheels.Count; i++)
        {
            int nextPosition = _numberGenerator.Generate();

            var column = wheels[i].Concat(wheels[i])
                .ToList()
                .GetRange(nextPosition, 6);
            screen.Add(column);
        }

        return screen;
    }
}