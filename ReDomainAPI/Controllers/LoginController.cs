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
    public ActionResult<string> Login([FromBody] LoginRequest request)
    {
        try
        {
            var token = _loginService.Login(request.Username, request.Password);
            return Ok(token);
        }
        catch (Exception e){
            return BadRequest(e.Message);
    }
    
}
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}