using Application.Exceptions;
using Application.Services.GetUser;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ReDomainAPI.Controllers;

namespace ReSlotGameTests;
using Application;
using Domain;
using Domain.Gateway;


public class GetUserControllerTests
{
    [Fact]
    public void 沒有找到User_回傳狀態碼400()
    {
        var mockService = new Mock<IGetUserService>();
       mockService.Setup(r => r.GetUser()).Throws<NotFoundUserException>();
        var controller = new UserController(mockService.Object);
        
        var res = controller.Get();
        
        Assert.True(res.Result is BadRequestObjectResult);
    }
    
    
    [Fact]
    public void 回傳狀態碼200()
    {
        var mockService = new Mock<IGetUserService>();
        mockService.Setup(r => r.GetUser()).Returns(new UserResponse("Roy", 1000));
        var controller = new UserController(mockService.Object);
        
        var res = controller.Get();

        var okResult = Assert.IsType<OkObjectResult>(res.Result);
    
        var value = Assert.IsType<UserResponse>(okResult.Value);
    
        Assert.Equal("Roy", value.Name);
        Assert.Equal(1000, value.UserMoney);
    }
}