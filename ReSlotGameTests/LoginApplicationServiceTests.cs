using Application.Exceptions;
using Application.Services.Login;
using Domain;
using Domain.Gateway;
using Moq;

namespace ReSlotGameTests;

public class LoginApplicationServiceTests
{
    [Fact]
    public void Login_WithCorrectCredentials_ShouldReturnToken()
    {
        var mockRepo = new Mock<UserRepositoryGateway>();
        var user = new User("Roy");
        mockRepo.Setup(r => r.FindFromToken("Roy")).Returns(user);
        
        var service = new LoginApplicationService(mockRepo.Object);
        var token = service.Login("Roy", "password7777");
        
        Assert.NotNull(token);
        Assert.NotEmpty(token);
    }
}


