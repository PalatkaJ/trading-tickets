using tickets_shop.Domain;

namespace tickets_shop.UI.Core.InputOutput;

public abstract class ConsoleIOTemplate
{
    private readonly StreamReader _reader = new (Console.OpenStandardInput());
    private readonly StreamWriter _writer = new (Console.OpenStandardOutput()) {AutoFlush = true};
    
    private readonly string _headline = new(AppConstants.HeadTitleBoarder, AppConstants.HeadLineLength);
    
    public string GetInput(string? prompt = null)
    {
        _writer.Write(prompt);
        return _reader.ReadLine()!;
    }

    public string GetInputInvisible(string? prompt = null)
    {
        _writer.Write(prompt);
        
        string res = "";
        ConsoleKeyInfo keyPressed = Console.ReadKey(true);
        
        while (keyPressed.Key != ConsoleKey.Enter)
        {
            res += keyPressed.KeyChar;
            keyPressed = Console.ReadKey(true);
        }
        
        return res;
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
        string emptySpace = new(' ', (AppConstants.HeadLineLength - title.Length)/2);
        return emptySpace + title.ToUpper() + emptySpace;
    }

    private void DisplayTitle()
    {
        ShowMessage($"""
                     {_headline}
                     {GetTransformedTitle(AppConstants.AppName)}
                     {_headline}
                     
                     """);  
    }

    protected abstract void DisplayBody();

    protected virtual void DisplayFooter() => ShowMessage("\n");
}