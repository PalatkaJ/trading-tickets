using tickets_trading.UI.Core.View;

namespace tickets_trading.UI.Features.Menus.MenuView;

public interface IMenuView: IView
{
    public IReadOnlyList<MenuItem>? Options { set; }
    
    public MenuItem ChooseOption();
}