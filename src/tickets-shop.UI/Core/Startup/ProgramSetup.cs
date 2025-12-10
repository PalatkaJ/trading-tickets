using Microsoft.AspNetCore.Identity;
using tickets_shop.Infrastructure.Database;
using tickets_shop.Application.Authentication;
using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Domain.Users;
using tickets_shop.Infrastructure.Authentication;

namespace tickets_shop.UI.Core.Startup;

/// <summary>
/// A helper class responsible for initializing and setting up all major
/// application dependencies (repositories and services).
/// </summary>
public static class ProgramSetup
{
    /// <summary>
    /// Instantiates and configures the concrete AuthenticationModule implementation.
    /// This includes creating and injecting the secure PasswordHasher.
    /// </summary>
    /// <param name="userRepo">The already initialized User Repository dependency.</param>
    /// <returns>A fully configured IAuthenticationModule instance.</returns>
    public static IAuthenticationModule SetUpAuthenticationService(IUserRepository userRepo)
    {
        var hasher = new PasswordHasher<User>();
        return new AuthenticationModule(userRepo, hasher);
    }

    /// <summary>
    /// Initializes all concrete repository implementations and returns them as a tuple
    /// of their interface types.
    /// </summary>
    /// <param name="db">The single, instantiated AppDbContext instance to be shared across all repositories.</param>
    /// <returns>A tuple containing the initialized IUserRepository, IEventsRepository, and ITicketsRepository.</returns>
    public static (IUserRepository, IEventsRepository, ITicketsRepository) InitializeRepositories(AppDbContext db)
    {
        var usersRepo = new UserRepository(db);
        var eventsRepo = new EventsRepository(db);
        var ticketsRepo = new TicketsRepository(db);
        
        return (usersRepo, eventsRepo, ticketsRepo);
    }
}