using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.AdminMenus;

public class AdminMainMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("Events", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.AdminEventsMenuBuilder?.Value;
        }));
        
        // TODO maybe add to UserTemplate bcs Reg User has that too
        items.Add(CreateItem("Account Information", () => { }));
    }
}