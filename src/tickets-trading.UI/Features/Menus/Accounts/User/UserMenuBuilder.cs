using tickets_trading.UI.Core.Views.OptionsView;

namespace tickets_trading.UI.Features.Menus.Accounts.User;

public class UserMenuBuilder: UsersMenuBuilderTemplate
{
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("My Tickets", () => { }));
        items.Add(CreateItem("Tickets Shop",() => { }));
        items.Add(CreateItem("Tickets Trading", () => { }));
        items.Add(CreateItem("Account Information", () => { }));
    }
}