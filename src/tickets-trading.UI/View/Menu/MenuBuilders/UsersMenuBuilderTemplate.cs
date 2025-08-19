namespace tickets_trading.UI.View.Menu.MenuBuilders;

public class UsersMenuBuilderTemplate: MenuBuilderTemplate
{
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("Log Out", () => { Console.WriteLine("TODO logging out....");}));
        base.BuildMiddleCore(items);
    }
}