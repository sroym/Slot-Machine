using System.Runtime.InteropServices.JavaScript;
using Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ReDomainAPI.Controllers;
using Domain;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly User _user;

    public UserController(User user)
    {
        _user = user;
    }

    [HttpGet]
    public ActionResult<UserResponse> Get()
    {
        try
        {
            return Ok(new UserResponse()
            {
                name = _user.GetName(),
                userMoney = _user.GetMoney(),
            });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}

public record struct UserResponse(string name, int userMoney);
