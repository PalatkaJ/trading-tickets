using tickets_trading.UI.View.Menu;

namespace tickets_trading.UI.View.Menu.MenuBuilders;

public interface IMenuBuilder
{
    List<MenuItem> BuildMenu()
    {
        var items = new List<MenuItem>();
        BuildMiddle(items);
        return items;
    }

    void BuildMiddle(List<MenuItem> items);
}