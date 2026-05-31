namespace ReSlotGameTests;
using Domain;
public class JwtTests
{
    [Fact]
    public void GenerateToken_ShouldReturnToken()
    {
        var jwtService = new JwtService("my-secret-key-is-long-enough");
        var token = jwtService.GenerateToken("Roy");
        Assert.NotNull(token);
        Assert.NotEmpty(token);
    }

    [Fact]
    public void ValidateToken_ShouldReturnToken()
    {
        var wjtService = new JwtService("my-secret-key-is-long-enough");
        var token = wjtService.GenerateToken("Roy");
        var userName = JwtService.ValidateToken(token);
        Assert.Equal("Roy", userName);
    }
}
