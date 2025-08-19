namespace tickets_trading.UI.View;

public interface IView
{
    public string GetInput(string? prompt = null);
    public void ShowMessage(string? message = null);

    public void DisplayContent();
}