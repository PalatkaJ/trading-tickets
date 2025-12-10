using Microsoft.EntityFrameworkCore;
using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Domain.Users;

namespace tickets_shop.Infrastructure.Database;

/// <summary>
/// Implements the IUserRepository contract using Entity Framework Core to
/// provide persistence and query operations for the User entity hierarchy.
/// </summary>
/// <param name="context">The application's database context used to interact with the data store.</param>
public class UserRepository(AppDbContext context): IUserRepository
{
    public void AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    /// <summary>
    /// Explicitly loads the complex navigation dependencies for a specific User based on their role.
    /// For Admin: Loads OrganizedEvents.
    /// For RegularUser: Loads OwnedTickets, and Eager Loads the related Event for each ticket (as it is needed).
    /// </summary>
    /// <param name="user">The tracked User object whose dependencies should be loaded.</param>
    public void EagerLoadUsersDependencies(User user)
    {
        switch (user)
        {
            case Admin admin:
                // Explicitly loads the ICollection<Event>
                context.Entry(admin)
                    .Collection(a => a.OrganizedEvents)
                    .Query()
                    .Load();
                break;
            case RegularUser ru:
                // Explicitly loads the ICollection<Ticket> and Loads the Event for each ticket
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