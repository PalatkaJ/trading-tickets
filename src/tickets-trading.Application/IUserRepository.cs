using tickets_trading.Domain;

namespace tickets_trading.Application;

public interface IUserRepository
{
    public void AddUser(User user);
    public User? GetUserById(Guid id);
    public User? GetUserByUsername(string username);
}