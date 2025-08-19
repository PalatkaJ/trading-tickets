using tickets_trading.Application.Services.ActionServices;

namespace tickets_trading.UI.View.Menu.MenuBuilders;

public class UserMenuBuilder(IView simpleView, IMenuView menuView): MenuBuilderTemplate(simpleView, menuView)
{
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("My Tickets", new EmptyActionService(() => { })));
        items.Add(CreateItem("Tickets Shop", new EmptyActionService(() => { })));
        items.Add(CreateItem("Tickets Trading", new EmptyActionService(() => { })));
        items.Add(CreateItem("Account Information", new EmptyActionService(() => { })));
        base.BuildMiddleCore(items);
    }
}