using tickets_trading.UI.Core.Views.OptionsView;

namespace tickets_trading.UI.Features.Menus.Accounts;

public class UsersMenuBuilderTemplate: MenuBuilderTemplate
{
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("Log Out", () => { Console.WriteLine("TODO logging out....");}));
    }
}