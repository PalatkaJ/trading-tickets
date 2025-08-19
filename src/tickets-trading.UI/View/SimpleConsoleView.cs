namespace tickets_trading.UI.View;

public class SimpleConsoleView: IView
{
    protected readonly StreamReader _reader = new (Console.OpenStandardInput());
    protected readonly StreamWriter _writer = new (Console.OpenStandardOutput()) {AutoFlush = true};
    
    public string GetInput(string? prompt = null)
    {
        _writer.Write(prompt);
        return _reader.ReadLine()!;
    }

    public void ShowMessage(string? message = null)
    {
        _writer.Write(message);
    }

    public void Display()
    {
        DisplayTitle();
        DisplayBody();
        DisplayFooter();
    }

    private void DisplayTitle()
    {
        ShowMessage("\n===============\nTICKETS TRADING\n===============\n");
    }

    protected virtual void DisplayBody() { }

    protected virtual void DisplayFooter()
    {
        ShowMessage("===============\n");
    }
}