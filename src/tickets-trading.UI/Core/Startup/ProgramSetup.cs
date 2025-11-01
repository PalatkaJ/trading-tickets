using tickets_trading.Application.Authentication;
using tickets_trading.Application.DatabaseAPI;
using tickets_trading.Infrastructure.Authentication;
using tickets_trading.Infrastructure.Database;
using tickets_trading.Infrastructure.Repositories;

namespace tickets_trading.UI.Core.Startup;

public static class ProgramSetup
{
    public static AuthenticationModule SetUpAuthenticationService(IUserRepository userRepo)
    {
        var hasher = new Pbkdf2PasswordHasher();
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