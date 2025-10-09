using tickets_trading.Application.Authentication;
using tickets_trading.Domain.Authentication;
using tickets_trading.Infrastructure.Database;

namespace tickets_trading.Infrastructure.Authentication;

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