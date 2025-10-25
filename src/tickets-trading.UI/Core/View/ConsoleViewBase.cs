namespace tickets_trading.UI.Core.View;

public abstract class ConsoleViewBase: IView
{
    private readonly StreamReader _reader = new (Console.OpenStandardInput());
    private readonly StreamWriter _writer = new (Console.OpenStandardOutput()) {AutoFlush = true};
    
    public string GetInput(string? prompt = null)
    {
        _writer.Write(prompt);
        return _reader.ReadLine()!;
    }

    public void ShowMessage(string? message = null) => _writer.Write(message);

    private void Clear() => Console.Clear();

    public void DisplayContent()
    {
        Clear();
        DisplayTitle();
        DisplayBody();
        DisplayFooter();
    }

    private void DisplayTitle() => ShowMessage("\n===============\nTICKETS TRADING\n===============\n");

    protected virtual void DisplayBody() {}

    protected virtual void DisplayFooter() => ShowMessage("\n");
}