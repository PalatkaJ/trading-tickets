namespace tickets_trading.UI.View.Menu.MenuBuilders;

public class AdminMenuBuilder: UsersMenuBuilderTemplate
{
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("Tickets Shop",() => { }));
        items.Add(CreateItem("Account Information", () => { }));
        base.BuildMiddleCore(items);
    }
}