namespace Domain.Gateway;

public interface UserRepositoryGateway
{
    User FindFromToken(string token);
}