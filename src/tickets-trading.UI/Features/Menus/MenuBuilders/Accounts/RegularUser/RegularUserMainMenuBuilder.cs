using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.RegularUser;

public class RegularUserMainMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("My Tickets", () => { }));
        items.Add(CreateItem("Tickets Shop",() => { }));
        items.Add(CreateItem("Tickets Trading", () => { }));
        items.Add(CreateItem("Account Information", () => { }));
    }
}