using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Admin;

public class AdminMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    protected override void BuildMiddleUserSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("Tickets Shop",() => { }));
        items.Add(CreateItem("Account Information", () => { }));
    }
}