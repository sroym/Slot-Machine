namespace Domain;

public class Screen
{
     public List<List<string>> _wheels { get; private set; }
        private  readonly INumberGenerator _numberGenerator;

    public Screen(List<List<string>> wheels, INumberGenerator numberGenerator)
    {
        _numberGenerator = numberGenerator;
        _wheels = wheels;
    }

    private List<List<string>> GetScreen(List<List<string>> wheels)
    {
        var screen =  new List<List<string>>();
        for (int i = 0; i < wheels.Count; i++)
        {
            int nextPosition = _numberGenerator.Gernerate();

            var column = wheels[i].Concat(wheels[i])
                .ToList()
                .GetRange(nextPosition, 3);
            screen.Add(column);
        }

        return screen;
    }
}