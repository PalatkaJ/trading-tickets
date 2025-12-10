using tickets_shop.Application.Authentication;
using tickets_shop.UI.Features.Menus.MenuBuilders.Authentication;
using tickets_shop.UI.Features.Menus.MenuBuilders.Users.AdminMenus;
using tickets_shop.UI.Features.Menus.MenuBuilders.Users.RegularUserMenus;

namespace tickets_shop.UI.Core.Startup;

/// <summary>
/// A static service class that acts as a central repository for all menu builder instances.
/// It uses the Lazy pattern to ensure that menu objects are only initialized
/// and constructed the very first time they are accessed, optimizing application startup.
/// </summary>
public static class LazyMenuBuildersLibrary
{
    private static IAuthenticationModule? _authModule;
    private static ApplicationState? _appState;
    
    public static Lazy<AuthenticationMenuBuilder>? AuthenticationMenuBuilder { get; private set; }
    
    public static Lazy<SignUpMenuBuilder>? SignUpMenuBuilder { get; private set; }
    
    public static Lazy<AdminMainMenuBuilder>? AdminMainMenuBuilder { get; private set; }
    
    public static Lazy<AdminEventsMenuBuilder>? AdminEventsMenuBuilder { get; private set; }
    
    public static Lazy<AdminEventsBrowserMenuBuilder>? AdminEventsBrowserMenuBuilder { get; private set; }
    
    public static Lazy<RegularUserMainMenuBuilder>? RegularUserMainMenuBuilder { get; private set; }
    
    public static Lazy<RegularUserTicketsShopMenuBuilder>? RegularUserBuyTicketsMenuBuilder { get; private set; }
    
    public static Lazy<RegularUserTicketsBrowserMenuBuilder>? RegularUserTicketsBrowserMenuBuilder { get; private set; }
    
    public static Lazy<RegularUserBrowseEventsMenuBuilder>? RegularUserBrowseEventsMenuBuilder { get; private set; }
    
    public static Lazy<RegularUserEventSubMenuBuilder>? RegularUserEventSubMenuBuilder { get; private set; }
    
    public static Lazy<RegularUserAccountInformationMenuBuilder>? RegularUserAccountInformationMenuBuilder { get; private set; }

    private static bool _initialized = false;

    /// <summary>
    /// Initializes all Lazy builders, setting up the necessary dependencies but deferring
    /// the actual object construction until the .Value property is first accessed.
    /// This method runs only once during initialization.
    /// </summary>
    /// <param name="appState">The application's state object to be injected into the builders.</param>
    /// <param name="authModule">The authentication service to be injected into relevant builders.</param>
    public static void Initialize(ApplicationState appState, IAuthenticationModule authModule)
    {
        if (_initialized)
            return;

        _authModule = authModule;
        _appState = appState;

        // ... all Lazy<T> initializations ...
        
        AuthenticationMenuBuilder = new Lazy<AuthenticationMenuBuilder>(
            () => new AuthenticationMenuBuilder(_authModule, _appState)
        );
        
        SignUpMenuBuilder = new Lazy<SignUpMenuBuilder>(
            () => new SignUpMenuBuilder(_authModule, _appState)
        );

        AdminMainMenuBuilder = new Lazy<AdminMainMenuBuilder>(
            () => new AdminMainMenuBuilder(_appState)
        );
        
        AdminEventsMenuBuilder = new Lazy<AdminEventsMenuBuilder>(
            () => new AdminEventsMenuBuilder(_appState)
        );
        
        AdminEventsBrowserMenuBuilder = new Lazy<AdminEventsBrowserMenuBuilder>(
            () => new AdminEventsBrowserMenuBuilder(_appState)
        );

        RegularUserMainMenuBuilder = new Lazy<RegularUserMainMenuBuilder>(
            () => new RegularUserMainMenuBuilder(_appState)
        );
        
        RegularUserBuyTicketsMenuBuilder = new Lazy<RegularUserTicketsShopMenuBuilder>(
            () => new RegularUserTicketsShopMenuBuilder(_appState)
        );
        
        RegularUserTicketsBrowserMenuBuilder = new Lazy<RegularUserTicketsBrowserMenuBuilder>(
            () => new RegularUserTicketsBrowserMenuBuilder(_appState)
        );
        
        RegularUserBrowseEventsMenuBuilder = new Lazy<RegularUserBrowseEventsMenuBuilder>(
            () => new RegularUserBrowseEventsMenuBuilder(_appState)
        );
        
        RegularUserEventSubMenuBuilder = new Lazy<RegularUserEventSubMenuBuilder>(
            () => new RegularUserEventSubMenuBuilder(_appState)
        );
        
        RegularUserAccountInformationMenuBuilder = new Lazy<RegularUserAccountInformationMenuBuilder>(
            () => new RegularUserAccountInformationMenuBuilder(_appState)
        );

        _initialized = true;
    }
}