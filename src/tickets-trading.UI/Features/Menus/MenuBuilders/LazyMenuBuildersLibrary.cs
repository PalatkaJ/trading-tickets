using tickets_trading.Application.Authentication;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Admin;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.RegularUser;
using tickets_trading.UI.Features.Menus.MenuBuilders.Authentication;

namespace tickets_trading.UI.Features.Menus.MenuBuilders;

public static class LazyMenuBuildersLibrary
{
    private static AuthenticationModule? _authModule;
    private static ApplicationState? _appState;

    public static Lazy<AuthenticationMenuBuilder>? AuthenticationMenuBuilder { get; private set; }
    public static Lazy<AdminMainMenuBuilder>? AdminMenuBuilder { get; private set; }
    public static Lazy<RegularUserMainMenuBuilder>? UserMenuBuilder { get; private set; }

    private static bool _initialized = false;

    public static void Initialize(ApplicationState appState, AuthenticationModule authModule)
    {
        if (_initialized)
            return;

        _authModule = authModule;
        _appState = appState;

        AuthenticationMenuBuilder = new Lazy<AuthenticationMenuBuilder>(
            () => new AuthenticationMenuBuilder(_authModule, _appState)
        );

        AdminMenuBuilder = new Lazy<AdminMainMenuBuilder>(
            () => new AdminMainMenuBuilder(_appState)
        );

        UserMenuBuilder = new Lazy<RegularUserMainMenuBuilder>(
            () => new RegularUserMainMenuBuilder(_appState)
        );

        _initialized = true;
    }
}
