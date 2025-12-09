using Microsoft.EntityFrameworkCore;
using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Domain.Users;

namespace tickets_shop.Infrastructure.Database;

public class UserRepository(AppDbContext context): IUserRepository
{
    public void AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public void EagerLoadUsersDependencies(User user)
    {
        switch (user)
        {
            case Admin admin:
                context.Entry(admin)
                    .Collection(a => a.OrganizedEvents)
                    .Query()
                    .Load();
                break;
            case RegularUser ru:
                context.Entry(ru)
                    .Collection(r => r.OwnedTickets)
                    .Query()
                    .Include(t => t.Event)
                    .Load();
                break;
        }
    }
    
    public User? GetUserById(Guid id) => context.Users.Find(id);
    public User? GetUserByUsernameLight(string username) 
        => context.Users.FirstOrDefault(u => u.Username == username);
}