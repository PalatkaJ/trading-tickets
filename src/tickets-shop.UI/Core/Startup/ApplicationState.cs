using Microsoft.EntityFrameworkCore;
using tickets_shop.UI.Features.Menus.MenuBuilders;
using tickets_shop.UI.Features.UIServices.Menu;
using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Domain.Users;

namespace tickets_shop.UI.Core.Startup;

/// <summary>
/// A central, mutable container that holds the current state of the application
/// (e.g., who is logged in, whether the application is running) and provides
/// access to essential service dependencies.
/// </summary>
public class ApplicationState
{
    /// <summary>
    /// Flag indicating whether the main application loop should continue running.
    /// Setting this to false causes the application to exit.
    /// </summary>
    public bool Running = true;
    
    /// <summary>
    /// The User entity (Admin or RegularUser) that is currently logged in. Null if no one is logged in.
    /// </summary>
    public User? CurrentUser;
    
    /// <summary>
    /// The currently active menu builder responsible for creating the visible menu structure.
    /// (the first menu is the authentication one)
    /// </summary>
    public MenuBuilderTemplate? MenuBuilder;
    
    /// <summary>
    /// The service responsible for displaying menus and choosing an option from a menu.
    /// </summary>
    public MenuService? MenuService;

    /// <summary>
    /// The Entity Framework Core database context used for the current session.
    /// </summary>
    public DbContext? DbContext;
    
    /// <summary>
    /// The repository for User entity data access.
    /// </summary>
    public IUserRepository? UserRepository;
    
    /// <summary>
    /// The repository for Ticket entity data access.
    /// </summary>
    public ITicketsRepository? TicketsRepository;
    
    /// <summary>
    /// The repository for Event entity data access.
    /// </summary>
    public IEventsRepository? EventsRepository;
}