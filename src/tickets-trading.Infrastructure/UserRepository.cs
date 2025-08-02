using tickets_trading.Domain;
using tickets_trading.Application;

namespace tickets_trading.Infrastructure;

public class UserRepository(AppDbContext context): IUserRepository
{
    private readonly AppDbContext _context = context;
    
    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User? GetUserById(Guid id) => _context.Users.Find(id);
    public User? GetUserByUsername(string username) => _context.Users.FirstOrDefault(u => u.Username == username);
}