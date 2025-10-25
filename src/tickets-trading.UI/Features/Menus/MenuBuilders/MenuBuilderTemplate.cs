using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders;

public abstract class MenuBuilderTemplate(ApplicationState applicationState): IMenuBuilder
{
    protected readonly ApplicationState ApplicationState = applicationState;
    
    protected MenuItem CreateItem(string title, Action action)
    {
        return new($"{GetType().Name}.{title.Replace(" ", "")}", $"{title}", action);
    }

    public void BuildMiddle(List<MenuItem> items)
    {
        BuildMiddleCore(items);
        items.Add(CreateItem($"Exit", () =>
        {
            ApplicationState.Running = false;
        }));   
    }

    protected abstract void BuildMiddleCore(List<MenuItem> items);
}