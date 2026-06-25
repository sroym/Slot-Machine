namespace Domain;

public interface ISlotMachine
{
    int Calculate(int bet);
    List<List<string>> GetScreen();
    List<int> GetStopIndexes();
}