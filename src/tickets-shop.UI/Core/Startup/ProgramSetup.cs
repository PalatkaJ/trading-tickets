using Microsoft.AspNetCore.Identity;
using tickets_shop.Infrastructure.Database;
using tickets_shop.Application.Authentication;
using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Domain.Users;
using tickets_shop.Infrastructure.Authentication;

namespace tickets_shop.UI.Core.Startup;

public static class ProgramSetup
{
    public static IAuthenticationModule SetUpAuthenticationService(IUserRepository userRepo)
    {
        var hasher = new PasswordHasher<User>();
        return new AuthenticationModule(userRepo, hasher);
    }

    public static (IUserRepository, IEventsRepository, ITicketsRepository) InitializeRepositories(AppDbContext db)
    {
        var usersRepo = new UserRepository(db);
        var eventsRepo = new EventsRepository(db);
        var ticketsRepo = new TicketsRepository(db);
        
        return (usersRepo, eventsRepo, ticketsRepo);
    }
}