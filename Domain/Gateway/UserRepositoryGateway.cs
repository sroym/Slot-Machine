namespace Domain.Gateway;

public interface UserRepositoryGateway
{
    User FindFromUsername(string username);
}