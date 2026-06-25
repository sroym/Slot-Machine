using Domain.Gateway;

namespace ReDomainAPI.Middlewares;

public class UserMiddleware
{
    private readonly RequestDelegate _next;
    private readonly UserRepositoryGateway _userRepository;

    public UserMiddleware(RequestDelegate next, UserRepositoryGateway userRepository)
    {
        _next = next;
        _userRepository = userRepository;
    }

    public async Task Invoke(HttpContext context)
    {
        var username = context.User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;
        if (username != null)
        {
            var user = _userRepository.FindFromToken(username);
            context.Items["User"] = user;
        }
        await _next(context);
    }
}