using Domain;
using Domain.Gateway;

namespace Application.Services.GetUser;

public interface IGetUserService
{
    UserResponse GetUser();
}

public record UserResponse(string Name, int UserMoney);
