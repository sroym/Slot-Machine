using Domain;
using Domain.Gateway;

namespace Infrastructure;


public class SqlUserRepository : UserRepositoryGateway
{
    public User FindFromToken(string token)
    {
        throw new NotImplementedException();
    }
}