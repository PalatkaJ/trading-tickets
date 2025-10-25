using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts;

public abstract class UsersMenuBuilderTemplate(ApplicationState applicationState): MenuBuilderTemplate(applicationState)
{
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        BuildMiddleSpecific(items);
        items.Add(CreateItem("Log Out", () =>
        {
            ApplicationState.CurrentUser = null;
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.AuthenticationMenuBuilder?.Value;
        }));
    }

    protected abstract void BuildMiddleSpecific(List<MenuItem> items);
}