namespace ReSlotGameTests;
using Domain;
public class LoginTests
{
    [Fact]
    public void Login_WithCorrect_Credentials()
    {
        var loginService = new LoginService("my-secret-key-is-long-enough=32chars!");
        var token = loginService.Login("Roy", "password7777");
        Assert.NotNull(token);
        Assert.NotEmpty(token);
    }
}