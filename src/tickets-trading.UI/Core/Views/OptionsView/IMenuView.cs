namespace tickets_trading.UI.Core.Views.OptionsView;

public interface IMenuView: IView
{
    public IReadOnlyList<MenuItem>? Options { set; }
    
    public MenuItem ChooseOption();
}