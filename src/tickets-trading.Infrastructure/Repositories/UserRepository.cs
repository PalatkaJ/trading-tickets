using tickets_trading.Application.DatabaseAPI;
using tickets_trading.Domain.Authentication;
using tickets_trading.Infrastructure.Database;

namespace tickets_trading.Infrastructure.Repositories;

public class UserRepository(AppDbContext context): IUserRepository
{
    public void AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public User? GetUserById(Guid id) => context.Users.Find(id);
    public User? GetUserByUsername(string username) 
        => context.Users.FirstOrDefault(u => u.Username == username);
}