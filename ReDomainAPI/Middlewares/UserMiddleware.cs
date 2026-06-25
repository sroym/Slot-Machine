using Domain.Gateway;

namespace ReDomainAPI.Middlewares;

public class UserMiddleware
{
    private readonly RequestDelegate _next;

    public UserMiddleware(RequestDelegate next, UserRepositoryGateway mockRepoObject)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, UserRepositoryGateway userRepository)
    {
        var username = context.User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;
        if (username != null)
        {
            var user = userRepository.FindFromUsername(username);
            context.Items["User"] = user;
        }
        await _next(context);
    }
}
