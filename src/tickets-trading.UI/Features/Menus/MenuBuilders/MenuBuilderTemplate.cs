using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders;

public abstract class MenuBuilderTemplate(ApplicationState applicationState)
{
    public abstract string Title { get; }
    
    protected readonly ApplicationState ApplicationState = applicationState;
    
    private int _currentFreeItemId = 1; 
    
    protected MenuItem CreateItem(string title, Action action)
    {
        return new(_currentFreeItemId++.ToString(), title, action);
    }

    protected MenuItem CreateItem(string id, string title, Action action)
    {
        return new(id, title, action);
    }

    protected NonSelectableMenuItem CreateNonSelectableItem(string content = "") => new(content);

    protected void ChangeMenuTo(MenuBuilderTemplate targetMenu)
    {
        ApplicationState.MenuBuilder = targetMenu;
        ApplicationState.MenuService!.MenuBuilder = targetMenu;
    }

    public List<MenuItem> BuildMenu()
    {
        var items = new List<MenuItem>();
        BuildMiddle(items);
        items.Add(CreateItem("e", "Exit", () =>
        {
            ApplicationState.Running = false;
        }));
        _currentFreeItemId = 1;
        return items;
    }

    protected abstract void BuildMiddle(List<MenuItem> items);
}