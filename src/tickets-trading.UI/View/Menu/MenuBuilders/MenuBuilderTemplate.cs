using tickets_trading.Application.Services;
using tickets_trading.Application.Services.ActionServices;

namespace tickets_trading.UI.View.Menu.MenuBuilders;

public abstract class MenuBuilderTemplate(IView simpleView, IMenuView menuView): IMenuBuilder
{
    protected IView _simpleView = simpleView;
    protected IMenuView _menuView = menuView;
    
    protected MenuItem CreateItem(string title, IService action)
    {
        return new($"{GetType().Name}.{title.Replace(" ", "")}", $"{title}", action);
    }

    protected virtual void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem($"Exit", new ExitService()));
    }

    public void BuildMiddle(List<MenuItem> items) => BuildMiddleCore(items);
    
}