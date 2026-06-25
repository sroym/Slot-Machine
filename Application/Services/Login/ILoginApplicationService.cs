namespace Application.Services.Login;

public interface ILoginApplicationService
{
    string Login(string username, string password);
    
}