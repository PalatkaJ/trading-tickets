using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Admin;

public class AdminMenuBuilder: UsersMenuBuilderTemplate
{
    protected override void BuildMiddleUserSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("Tickets Shop",() => { }));
        items.Add(CreateItem("Account Information", () => { }));
    }
}