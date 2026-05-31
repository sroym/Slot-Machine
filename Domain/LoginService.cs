namespace Domain;

public class LoginService
{
    private readonly JwtService _jwtService;

    public LoginService(string secretKey)
    {
        _jwtService = new JwtService(secretKey);
    }

    public string Login(string userName, string password)
    {
        if (userName == "Roy" && password == "password7777")
        {
            return _jwtService.GenerateToken(userName);
        }
        throw new Exception("帳號或密碼錯誤");
    }
}