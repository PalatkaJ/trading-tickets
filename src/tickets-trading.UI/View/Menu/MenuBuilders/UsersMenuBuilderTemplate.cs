using tickets_trading.Application.Services.ActionServices;

namespace tickets_trading.UI.View.Menu.MenuBuilders;

public class UsersMenuBuilderTemplate(IView simpleView, IMenuView menuView): MenuBuilderTemplate(simpleView, menuView)
{
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("Log Out", new EmptyActionService(() => { Console.WriteLine("TODO logging out....");})));
        base.BuildMiddleCore(items);
    }
}