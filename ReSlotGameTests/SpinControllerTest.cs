using Application.Exceptions;
using Application.Services.Spin;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ReDomainAPI.Controllers;

namespace ReSlotGameTests;

public class SpinControllerTests
{
    [Fact]
    public void Spin_WhenSuccess_ShouldReturn200()
    {
        var mockService = new Mock<ISpinService>();
        var spinResponse = new SpinResponse(990, new List<List<string>>(), new List<int>());
        mockService.Setup(s => s.Spin(10)).Returns(spinResponse);
        var controller = new SlotController(mockService.Object);

        var result = controller.Spin(10);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var value = Assert.IsType<SpinResponse>(okResult.Value);
        Assert.Equal(990, value.UserMoney);
    }

    [Fact]
    public void Spin_WhenUserNotFound_ShouldReturn400()
    {
        var mockService = new Mock<ISpinService>();
        mockService.Setup(s => s.Spin(10)).Throws<NotFoundUserException>();
        var controller = new SlotController(mockService.Object);

        var result = controller.Spin(10);

        Assert.IsType<BadRequestObjectResult>(result);
    }
}
