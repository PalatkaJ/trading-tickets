namespace tickets_trading.UI.Core.View;

public abstract class ConsoleViewBase: IView
{
    private readonly StreamReader _reader = new (Console.OpenStandardInput());
    private readonly StreamWriter _writer = new (Console.OpenStandardOutput()) {AutoFlush = true};
    
    private readonly string _headline = new('=', HeadlineLength);
    private readonly string _headTitle = "tickets trading"; 
    
    protected const int HeadlineLength = 45;
    
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

    protected string GetTransformedTitle(string title)
    {
        string emptySpace = new(' ', (HeadlineLength - title.Length)/2);
        return emptySpace + title.ToUpper() + emptySpace;
    }
    
    private void DisplayTitle() => ShowMessage($"{_headline}\n{GetTransformedTitle(_headTitle)}\n{_headline}\n");

    protected virtual void DisplayBody() {}

    protected virtual void DisplayFooter() => ShowMessage("\n");
}