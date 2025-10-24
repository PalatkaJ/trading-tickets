using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.User;

public class UserMenuBuilder: UsersMenuBuilderTemplate
{
    protected override void BuildMiddleUserSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("My Tickets", () => { }));
        items.Add(CreateItem("Tickets Shop",() => { }));
        items.Add(CreateItem("Tickets Trading", () => { }));
        items.Add(CreateItem("Account Information", () => { }));
    }
}