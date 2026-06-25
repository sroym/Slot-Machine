using Application.Exceptions;
using Domain;
using Domain.Gateway;
using Microsoft.AspNetCore.Http;
using Moq;
using ReDomainAPI.Middlewares;

namespace ReSlotGameTests;

public class UserMiddlewareTests
{
    [Fact]
    public async Task 有username_把User放進HttpContext()
    {
        var mockRepo = new Mock<UserRepositoryGateway>();
        var user = new User("Roy");
        mockRepo.Setup(r => r.FindFromToken("Roy")).Returns(user);
        
        var context = new DefaultHttpContext();
        var identity = new System.Security.Claims.ClaimsIdentity(new[]
        {
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "Roy")
        }, "test");
        context.User = new System.Security.Claims.ClaimsPrincipal(identity);
        
        var middleware = new UserMiddleware(_ => Task.CompletedTask, mockRepo.Object);
        await middleware.Invoke(context);
        
        Assert.Equal(user, context.Items["User"]);
    }
}