using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts;

public abstract class UsersMenuBuilderTemplate: MenuBuilderTemplate
{
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        BuildMiddleUserSpecific(items);
        items.Add(CreateItem("Log Out", () => { Console.WriteLine("TODO logging out....");}));
    }

    protected abstract void BuildMiddleUserSpecific(List<MenuItem> items);
}