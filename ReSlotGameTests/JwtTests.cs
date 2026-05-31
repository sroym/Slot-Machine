namespace ReSlotGameTests;

public class JwtTests
{
    [Fact]
    public void ShouldReturnToken()
    {
        var jwtService = new JwtService("my-secreat-key-is-long-enough");
        var token = jwtService.GenerateToken("Roy");
        Assert.NotNull(token);
        Assert.NotEmpty(token);
    }
}
