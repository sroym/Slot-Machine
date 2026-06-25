using Application.Exceptions;
using Application.Services.Login;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ReDomainAPI.Controllers;

namespace ReSlotGameTests;

public class LoginControllerTests
{
    [Fact]
    public void Login_WithCorrectCredentials_ShouldReturn200()
    {
        var mockService = new Mock<ILoginApplicationService>();
        mockService.Setup(s => s.Login("Roy", "password7777")).Returns("fake-token");
        var controller = new LoginController(mockService.Object);
        
        var result = controller.Login(new LoginController.LoginRequest { Username = "Roy", Password = "password7777" });
        
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("fake-token", okResult.Value);
    }

    [Fact]
    public void Login_WithWrongCredentials_ShouldReturn400()
    {
        var mockService = new Mock<ILoginApplicationService>();
        mockService.Setup(s => s.Login("Roy", "wrong")).Throws<NotFoundUserException>();
        var controller = new LoginController(mockService.Object);
        
        var result = controller.Login(new LoginController.LoginRequest { Username = "Roy", Password = "wrong" });
        
        Assert.IsType<BadRequestObjectResult>(result);
    }
}
