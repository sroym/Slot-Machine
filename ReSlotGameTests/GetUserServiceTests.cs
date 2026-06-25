using Application.Exceptions;
using Application.Services.GetUser;
using Domain;
using Domain.Gateway;
using Microsoft.AspNetCore.Http;
using Moq;

namespace ReSlotGameTests;

public class GetUserServiceTests
{
    [Fact]
    public void GetUser_WhenUserFound_ShouldReturnUserResponse()
    {
        var mockRepo = new Mock<UserRepositoryGateway>();
        var mockHttpContext = new Mock<IHttpContextAccessor>();
        var user = new User("Roy");
        user.SetBet(1000);
        mockHttpContext.Setup(h => h.HttpContext!.Items["User"]).Returns(user);
        var service = new GetUserService(mockRepo.Object, mockHttpContext.Object);
        var result = service.GetUser();
        Assert.Equal("Roy", result.Name);
        Assert.Equal(1000, result.UserMoney);
    }

    [Fact]
    public void GetUser_WhenUserNotFound_ShouldThrow()
    {
        var mockRepo = new Mock<UserRepositoryGateway>();
        var mockHttpContext = new Mock<IHttpContextAccessor>();
        mockHttpContext.Setup(h => h.HttpContext!.Items["User"]).Returns(null);
        var service = new GetUserService(mockRepo.Object, mockHttpContext.Object);
        Assert.ThrowsAny<NotFoundUserException>(() => service.GetUser());
    }
}
