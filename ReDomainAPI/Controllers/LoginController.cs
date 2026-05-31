using Microsoft.AspNetCore.Http.HttpResults;

namespace ReDomainAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Domain;

[ApiController]
[Route("[controller]")]
public class LoginController:ControllerBase
{
    private readonly LoginService _loginService;
    
    public LoginController(LoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public ActionResult<string> Login(string username, string password)
    {
        try
        {
            var token = _loginService.Login(username, password);
            return Ok(token);
        }
        catch (Exception e){
            return BadRequest(e.Message);
    }
    
}
}