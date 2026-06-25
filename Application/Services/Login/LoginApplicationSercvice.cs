using Application.Exceptions;
using Domain;
using Domain.Gateway;

namespace Application.Services.Login;

public class LoginApplicationService :  ILoginApplicationService
{
    private readonly UserRepositoryGateway _userRepository;
    private readonly IJwtService _jwtService;
    public LoginApplicationService(UserRepositoryGateway userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    

    public string Login(string username, string password)
    {
        var user = _userRepository.FindFromUsername(username);
        if (user == null) throw new NotFoundUserException();
        return _jwtService.GenerateToken(username);
    }
    
}