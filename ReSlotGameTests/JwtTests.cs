namespace ReSlotGameTests;
using Domain;
public class JwtTests
{
    [Fact]
    public void GenerateToken_ShouldReturnToken()
    {
        var jwtService = new JwtService("my-secret-key-is-long-enough-32chars!");
        var token = jwtService.GenerateToken("Roy");
        Assert.NotNull(token);
        Assert.NotEmpty(token);
    }

    [Fact]
    public void ValidateToken_ShouldReturnToken()
    {
        var jwtService = new JwtService("my-secret-key-is-long-enough-32chars!");
        var token = jwtService.GenerateToken("Roy");
        var userName = jwtService.ValidateToken(token);
        Assert.Equal("Roy", userName);
    }
}
