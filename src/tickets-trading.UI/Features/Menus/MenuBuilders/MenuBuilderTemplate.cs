using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders;

public abstract class MenuBuilderTemplate(ApplicationState applicationState): IMenuBuilder
{
    protected readonly ApplicationState ApplicationState = applicationState;
    private int _currentFreeItemId = 1; 
    
    protected MenuItem CreateItem(string title, Action action)
    {
        return new(_currentFreeItemId++, $"{title}", action);
    }

    protected NonSelectableMenuItem CreateNonSelectableItem(string content = "") => new(content);

    public void BuildMiddle(List<MenuItem> items)
    {
        BuildMiddleCore(items);
        items.Add(CreateItem($"Exit", () =>
        {
            ApplicationState.Running = false;
        }));
        _currentFreeItemId = 1;
    }

    protected abstract void BuildMiddleCore(List<MenuItem> items);
}