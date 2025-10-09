using tickets_trading.UI.Core.Views.OptionsView;

namespace tickets_trading.UI.Features.Menus;

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