namespace Domain;

public class RandomNumberGenerator(int uperBound) : INumberGenerator
{
    public int Generate()
    {
        var random = new Random();
        return random.Next(uperBound);
    }
}