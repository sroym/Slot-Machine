using Application.Exceptions;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Spin;

public class SpinService : ISpinService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ISlotMachine _slotMachine;

    public SpinService(IHttpContextAccessor httpContextAccessor, ISlotMachine slotMachine)
    {
        _httpContextAccessor = httpContextAccessor;
        _slotMachine = slotMachine;
        
    }

    public SpinResponse Spin(int bet)
    {
        var user = _httpContextAccessor.HttpContext?.Items["User"] as User;
        if (user == null) throw new NotFoundUserException();

        user.Spin(_slotMachine, bet);
        
        return new SpinResponse(
            user.GetMoney(),
            _slotMachine.GetScreen(),
            _slotMachine.GetStopIndexes()
        );
    }
}