namespace ReSlotGameTests;
using Application;
using Domain;
using Domain.Gateway;

public class GetUserServiceTests
{
    [Fact]
    public void GetUser_WhenUserNotFound_ShouldThrow()
    {
        var mockRepo = new NotFoundUserRepository();
        var service = new GetUserService(mockRepo);
        Assert.ThrowsAny<NotFoundUserException>(() => service.GetUser("fake-token"));
    }
}

public class NotFoundUserRepository : UserRepositoryGateway
{
    public User FindFromToken(string token)
    {
        throw new NotFoundUserException("");
    }
}