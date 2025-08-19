using tickets_trading.Application.Services.ActionServices;
using tickets_trading.UI.Services.HelpServices;

namespace tickets_trading.UI.View.Menu.MenuBuilders;

public class AuthenticationMenuBuilder(IView simpleView, IMenuView menuView): MenuBuilderTemplate(simpleView, menuView)
{
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("Sign Up", new EmptyActionService(() => { })));
        items.Add(CreateItem("Log In", new EmptyActionService(() => { })));
        items.Add(CreateItem("Help", new AuthenticationHelpService()));
        base.BuildMiddleCore(items);
    }
}