using Application.Exceptions;
using Domain;
using Domain.Gateway;
namespace Application.Services.GetUser;

public class GetUserService: IGetUserService
{
    private readonly UserRepositoryGateway _userRepository;

    public GetUserService(UserRepositoryGateway userRepository)
    {
        _userRepository = userRepository;
    }

    public User GetUser()
    {
        throw new NotFoundUserException();
    }
}