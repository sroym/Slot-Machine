namespace Domain.Gateway;

public interface UserRepositoryGateway
{
    User FindFromUsername(string username);
    User FindFromUsernameAndPassword(string username, string password);
}