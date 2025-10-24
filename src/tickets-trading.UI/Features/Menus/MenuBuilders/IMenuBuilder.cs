using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders;

public interface IMenuBuilder
{
    public List<MenuItem> BuildMenu()
    {
        var items = new List<MenuItem>();
        BuildMiddle(items);
        return items;
    }

    public void BuildMiddle(List<MenuItem> items);
}