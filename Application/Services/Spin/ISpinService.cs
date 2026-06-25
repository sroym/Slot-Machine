namespace Application.Services.Spin;

public interface ISpinService
{
    SpinResponse Spin(int bet);
}
public record SpinResponse(int UserMoney, List<List<string>> Screen, List<int> StopIndex);
