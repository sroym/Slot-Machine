namespace Domain;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class JwtService
{
    private readonly string _secretKey;

    public JwtService(string secretKey)
    {
        _secretKey = secretKey;
    }

    public string GenerateToken(string username)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string  ValidateToken(string token, DateTime? now = null)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var tokenHandler = new JwtSecurityTokenHandler();
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false,
            LifetimeValidator = (notBefore, expires, securityToken, parameters) =>
            {
                var currenTime = now ?? DateTime.UtcNow;
                return expires > currenTime;
            }
        }, out SecurityToken validatedToken);
        var jwtToken = (JwtSecurityToken)validatedToken;
        return jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value;
    }
}