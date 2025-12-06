using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Common;

public abstract class UsersMenuBuilderTemplate(ApplicationState applicationState): MenuBuilderTemplate(applicationState)
{
    protected override void BuildMiddle(List<MenuItem> items)
    {
        BuildMiddleSpecific(items);
        items.Add(CreateItem("m", "Main Menu", () =>
        {
            ChangeMenuTo(ApplicationState.CurrentUser is Admin
                ? LazyMenuBuildersLibrary.AdminMainMenuBuilder!.Value
                : LazyMenuBuildersLibrary.RegularUserMainMenuBuilder!.Value);
        }));
        items.Add(CreateItem("l","Log Out", () =>
        {
            ApplicationState.CurrentUser = null;
            ChangeMenuTo(LazyMenuBuildersLibrary.AuthenticationMenuBuilder!.Value);
        }));
    }

    protected abstract void BuildMiddleSpecific(List<MenuItem> items);
}