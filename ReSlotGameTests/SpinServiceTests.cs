using Application.Exceptions;
using Application.Services.Spin;
using Domain;
using Microsoft.AspNetCore.Http;
using Moq;

namespace ReSlotGameTests;

public class SpinServiceTests
{
    [Fact]
    public void Spin_WhenUserFound_ShouldReturnSpinResponse()
    {
        var mockHttpContext = new Mock<IHttpContextAccessor>();
        var mockSlot = new Mock<ISlotMachine>();
        var user = new User("Roy");
        user.SetBet(1000);

        mockHttpContext.Setup(h => h.HttpContext!.Items["User"]).Returns(user);
        mockSlot.Setup(s => s.Calculate(10)).Returns(100);
        mockSlot.Setup(s => s.GetScreen()).Returns(new List<List<string>>());
        mockSlot.Setup(s => s.GetStopIndexes()).Returns(new List<int>());

        var service = new SpinService(mockHttpContext.Object, mockSlot.Object);
        var result = service.Spin(10);

        Assert.NotNull(result);
    }

    [Fact]
    public void Spin_WhenUserNotFound_ShouldThrow()
    {
        var mockHttpContext = new Mock<IHttpContextAccessor>();
        var mockSlot = new Mock<ISlotMachine>();

        mockHttpContext.Setup(h => h.HttpContext!.Items["User"]).Returns(null);

        var service = new SpinService(mockHttpContext.Object, mockSlot.Object);
        Assert.ThrowsAny<NotFoundUserException>(() => service.Spin(10));
    }
}