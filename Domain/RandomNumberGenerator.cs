namespace Domain;

public class RandomNumberGenerator(int upperBound) : INumberGenerator
{
    public int Generate()
    {
        var random = new Random();
        return random.Next(upperBound);
    }
}