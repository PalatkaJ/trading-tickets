using tickets_trading.Application.Services.ActionServices;
using tickets_trading.UI.View.Menu;

namespace tickets_trading.UI.View.Menu.MenuBuilders;

public class AdminMenuBuilder(IView simpleView, IMenuView menuView): MenuBuilderTemplate(simpleView, menuView)
{
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("Tickets Shop", new EmptyActionService(() => { })));
        items.Add(CreateItem("Account Information", new EmptyActionService(() => { })));
        base.BuildMiddleCore(items);
    }
}