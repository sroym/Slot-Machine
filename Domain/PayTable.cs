namespace Domain;
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
