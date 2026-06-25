using Domain;
using Domain.Gateway;

namespace Infrastructure;


public class SqlUserRepository : UserRepositoryGateway
{
    public User FindFromUsername(string username)
    {
        return null;
    }
    public User FindFromUsernameAndPassword(string username, string password)
    {
        return null;
    }
}
