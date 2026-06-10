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
    
    [Fact]
    public void ValidateToken_WithExpiredToken_ShouldThrow()
    {
        var jwtService = new JwtService("my-secret-key-is-long-enough-32chars!");
        var token = jwtService.GenerateToken("Roy");
        Assert.ThrowsAny<Exception>(() => jwtService.ValidateToken(token, DateTime.UtcNow.AddHours(2)));
    }
}
