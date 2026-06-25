using Application.Exceptions;
using Domain;
using Domain.Gateway;
using Microsoft.AspNetCore.Http;

namespace Application.Services.GetUser;

public class GetUserService: IGetUserService
{
    private readonly UserRepositoryGateway _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetUserService(UserRepositoryGateway userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public UserResponse GetUser()
    {
        var user = _httpContextAccessor.HttpContext?.Items["User"] as User;
        if (user == null) throw new NotFoundUserException();
        return new UserResponse(user.GetName(), user.GetMoney());
    }
}