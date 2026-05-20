namespace Domain;

public class SpecifyNumberGenerator(List<int> numbers) : INumberGenerator
{
    public int Generate()
    {
        var number = numbers[0];
        numbers.RemoveAt(0);
        return number;
    }

}