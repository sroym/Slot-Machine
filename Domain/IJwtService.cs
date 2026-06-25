namespace Domain;

public interface IJwtService
{
    string GenerateToken(string username);
    string ValidateToken(string token, DateTime? now = null);
}