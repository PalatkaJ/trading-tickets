using tickets_trading.Domain.Authentication;

namespace tickets_trading.Application.DatabaseAPI;

public interface IUserRepository
{
    public void AddUser(User user);
    public User? GetUserById(Guid id);
    public User? GetUserByUsername(string username);
}