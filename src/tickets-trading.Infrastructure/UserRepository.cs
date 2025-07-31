using tickets_trading.Domain;

namespace tickets_trading.Infrastructure;

public class UserRepository(AppDbContext context): IUserRepository
{
    public void AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public User? GetUserById(Guid id) => context.Users.Find(id);
    public User? GetUserByUsername(string username) => context.Users.FirstOrDefault(u => u.Username == username);
}