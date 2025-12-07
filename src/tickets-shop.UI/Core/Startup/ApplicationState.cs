using Microsoft.EntityFrameworkCore;
using tickets_shop.Domain;
using tickets_shop.UI.Features.Menus.MenuBuilders;
using tickets_shop.UI.Features.UIServices.Menu;
using tickets_shop.Application.DatabaseAPI;

namespace tickets_shop.UI.Core.Startup;

public class ApplicationState
{
    public bool Running = true;
    
    public User? CurrentUser;
    public MenuBuilderTemplate? MenuBuilder;
    public MenuService? MenuService;

    public DbContext? DbContext;
    
    public IUserRepository? UserRepository;
    public ITicketsRepository? TicketsRepository;
    public IEventsRepository? EventsRepository;
}