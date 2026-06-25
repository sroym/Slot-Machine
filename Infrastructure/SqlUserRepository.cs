using Domain;
using Domain.Gateway;

namespace Infrastructure;


public class SqlUserRepository : UserRepositoryGateway
{
    public User FindFromToken(string token)
    {
        return null;
    }
    public User FindFromUsername(string username)
    {
        return null;
    }
}
