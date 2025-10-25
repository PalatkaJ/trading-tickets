using tickets_trading.Application.Authentication;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Admin;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.User;
using tickets_trading.UI.Features.Menus.MenuBuilders.Authentication;

namespace tickets_trading.UI.Features.Menus.MenuBuilders;

public static class LazyMenuBuildersLibrary
{
    private static AuthenticationModule? _authModule;
    private static ApplicationState? _appState;

    public static Lazy<AuthenticationMenuBuilder>? AuthenticationMenuBuilder { get; private set; }
    public static Lazy<AdminMenuBuilder>? AdminMenuBuilder { get; private set; }
    public static Lazy<UserMenuBuilder>? UserMenuBuilder { get; private set; }

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

        AdminMenuBuilder = new Lazy<AdminMenuBuilder>(
            () => new AdminMenuBuilder(_appState)
        );

        UserMenuBuilder = new Lazy<UserMenuBuilder>(
            () => new UserMenuBuilder(_appState)
        );

        _initialized = true;
    }
}
