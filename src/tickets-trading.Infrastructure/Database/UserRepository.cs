using Microsoft.EntityFrameworkCore;
using tickets_trading.Application.DatabaseAPI;
using tickets_trading.Domain;

namespace tickets_trading.Infrastructure.Database;

public class UserRepository(AppDbContext context): IUserRepository
{
    public void AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public void LoadUsersDependencies(User user)
    { 
        if (user is Admin admin)
        {
            context.Entry(admin)
                .Collection(a => a.OrganizedEvents)
                .Query()
                .Include(e => e.Tickets)
                .Load();
        }
        else if (user is RegularUser ru)
        {
            context.Entry(ru)
                .Collection(r => r.OwnedTickets)
                .Query()
                .Include(t => t.Event)
                .Load();
        }
    }
    
    public User? GetUserById(Guid id) => context.Users.Find(id);
    public User? GetUserByUsernameLight(string username) 
        => context.Users.FirstOrDefault(u => u.Username == username);
}