using tickets_trading.UI.Core.Views.OptionsView;

namespace tickets_trading.UI.Features.Menus.Accounts.Admin;

public class AdminMenuBuilder: UsersMenuBuilderTemplate
{
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("Tickets Shop",() => { }));
        items.Add(CreateItem("Account Information", () => { }));
    }
}