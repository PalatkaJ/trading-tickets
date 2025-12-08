using tickets_shop.Domain;
using tickets_shop.Domain.Users;

namespace tickets_shop.Application.DatabaseAPI;

public interface IUserRepository
{
    public void AddUser(User user);
    public User? GetUserById(Guid id);
    public User? GetUserByUsernameLight(string username);

    public void EagerLoadUsersDependencies(User id);
}