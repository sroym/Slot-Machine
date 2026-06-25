using Application.Services.Login;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ReDomainAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Domain;

[ApiController]
[Route("[controller]")]
public class LoginController:ControllerBase
{
    private readonly ILoginApplicationService _loginService;
    
    public LoginController(ILoginApplicationService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest request)
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