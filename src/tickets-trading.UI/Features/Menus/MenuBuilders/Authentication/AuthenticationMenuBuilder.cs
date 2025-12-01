using tickets_trading.Application.Authentication;
using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Authentication;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Authentication;

public class AuthenticationMenuBuilder: MenuBuilderTemplate
{
    private readonly LogInUIService _logInUiService;

    private Action<User> OnUserFound;

    public AuthenticationMenuBuilder(AuthenticationModule authModule, ApplicationState applicationState): base(applicationState)
    {
        OnUserFound = user =>
        {
            ApplicationState.CurrentUser = user;
            ApplicationState.MenuBuilder = user is Admin ? 
                LazyMenuBuildersLibrary.AdminMainMenuBuilder!.Value
                : LazyMenuBuildersLibrary.RegularUserMainMenuBuilder!.Value;
        };
        
        _logInUiService = new(authModule)
        {
            OnUserFound = OnUserFound
        };
    }
    
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("Sign Up", () =>
        {
            LazyMenuBuildersLibrary.SignUpMenuBuilder!.Value.OnUserFound = OnUserFound;
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.SignUpMenuBuilder.Value;
        }));
        items.Add(CreateItem("Log In", () =>
        {
            _logInUiService.Execute();
        }));
        items.Add(CreateNonSelectableItem());
    }
}