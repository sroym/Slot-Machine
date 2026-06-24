using Domain;
using Domain.Gateway;
namespace Application;

public class GetUserService
{
    private readonly UserRepositoryGateway _userRepository;

    public GetUserService(UserRepositoryGateway userRepository)
    {
        _userRepository = userRepository;
    }

    public User GetUser(string token)
    {
        throw new NotImplementedException();
    }
}