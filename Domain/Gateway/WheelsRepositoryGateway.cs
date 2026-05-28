namespace Domain.Gateway;

public interface WheelsRepositoryGateway
{
    List<List<string>> GetFromUser(User user);
}