using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Admin;

public class AdminMainMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("Events", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.AdminTicketsShopMenuBuilder?.Value;
        }));
        items.Add(CreateItem("Account Information", () => { }));
    }
}