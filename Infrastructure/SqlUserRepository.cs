using Domain;
using Domain.Gateway;

namespace Infrastructure;


public class SqlUserRepository : UserRepositoryGateway
{
    public User FindFromUsername(string username)
    {
        return null;
    }
}
