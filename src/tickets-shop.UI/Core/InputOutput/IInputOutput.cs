namespace tickets_shop.UI.Core.InputOutput;

public interface IInputOutput
{
    public string GetInput(string prompt);
    public void ShowMessage(string message);
}