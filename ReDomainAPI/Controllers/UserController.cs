using Application;
using Application.Exceptions;
using Application.Services.GetUser;
using Microsoft.AspNetCore.Authorization;

namespace ReDomainAPI.Controllers;
using Domain;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController(IGetUserService getUserService) : ControllerBase
{
    
    [HttpGet]
    public ActionResult<UserResponse> Get()
    {
        try
        {
            var res = getUserService.GetUser();
            return Ok(res);
        }
        catch (NotFoundUserException)
        {
            return BadRequest("User not found");
        }
    }
    
}

