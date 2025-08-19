namespace tickets_trading.UI.View.Menu;

public interface IMenuView: IView
{
    public IReadOnlyList<MenuItem>? Options { set; }
    
    public MenuItem ChooseOption();
}