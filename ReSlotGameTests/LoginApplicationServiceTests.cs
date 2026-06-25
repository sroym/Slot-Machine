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
        var mockJwt = new Mock<IJwtService>();
        var user = new User("Roy");
        mockRepo.Setup(r => r.FindFromUsername("Roy")).Returns(user);
        mockJwt.Setup(j => j.GenerateToken("Roy")).Returns("fake-token");
    
        var service = new LoginApplicationService(mockRepo.Object, mockJwt.Object);
        var token = service.Login("Roy", "password7777");
    
        Assert.Equal("fake-token", token);
    }

    [Fact]

    public void Login_WithWrongCredentials_ShouldReturnNull()
    {
        var mockRepo = new Mock<UserRepositoryGateway>();
        var mockJwt = new Mock<IJwtService>();
        mockRepo.Setup(r => r.FindFromUsername("WrongUser")).Returns((User)null);
        
        var service = new LoginApplicationService(mockRepo.Object, mockJwt.Object);
        Assert.ThrowsAny<NotFoundUserException>(() => service.Login("WrongUser", "password7777"));
    }
}


