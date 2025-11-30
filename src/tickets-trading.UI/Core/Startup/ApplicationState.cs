using Microsoft.EntityFrameworkCore;
using tickets_trading.Application.DatabaseAPI;
using tickets_trading.Domain;
using tickets_trading.UI.Features.Menus.MenuBuilders;

namespace tickets_trading.UI.Core.Startup;

public class ApplicationState
{
    public bool Running = true;
    
    public User? CurrentUser;
    public IMenuBuilder? MenuBuilder;

    public DbContext? DbContext;
    
    public IUserRepository? UserRepository;
    public ITicketsRepository? TicketsRepository;
    public IEventsRepository? EventsRepository;
}