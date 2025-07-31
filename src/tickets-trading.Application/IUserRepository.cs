namespace tickets_trading.Domain;

public interface IUserRepository
{
    public void AddUser(User user);
    public User? GetUserById(Guid id);
    public User? GetUserByUsername(string username);
}