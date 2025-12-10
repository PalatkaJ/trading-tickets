using tickets_shop.Domain;

namespace tickets_shop.UI.Core.InputOutput;

/// <summary>
/// Provides a base template for creating standardized console-based views (pages or screens).
/// It handles global formatting, standard input/output streams, and the overall display structure.
/// </summary>
public abstract class ConsoleIOTemplate
{
    // These streams ensure reliable, non-buffered I/O operations.
    private readonly StreamReader _reader = new (Console.OpenStandardInput());
    private readonly StreamWriter _writer = new (Console.OpenStandardOutput()) {AutoFlush = true};
    
    // Generates a decorative headline based on application constants.
    private readonly string _headline = new(AppConstants.HeadTitleBoarder, AppConstants.WindowWidth);
    
    /// <summary>
    /// Reads a line of text input from the console after displaying an optional prompt.
    /// </summary>
    /// <param name="prompt">The message to display before reading input (optional).</param>
    /// <returns>The line of text entered by the user.</returns>
    protected string GetInput(string? prompt = null)
    {
        _writer.Write(prompt);
        return _reader.ReadLine()!;
    }

    /// <summary>
    /// Reads a line of text input from the console without echoing the characters to the screen.
    /// Used primarily for securely inputting passwords or sensitive data.
    /// </summary>
    /// <param name="prompt">The message to display before reading input (optional).</param>
    /// <returns>The line of text entered by the user.</returns>
    protected string GetInputInvisible(string? prompt = null)
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

    /// <summary>
    /// Writes a message to the console output stream.
    /// </summary>
    /// <param name="message">The message to display (optional).</param>
    protected void ShowMessage(string? message = null) => _writer.Write(message);

    /// <summary>
    /// Clears the entire console window.
    /// </summary>
    private void Clear() => Console.Clear();

    /// <summary>
    /// Executes the full drawing pipeline for the console screen: clear, title, body, and footer.
    /// </summary>
    public void DisplayContent()
    {
        Clear();
        DisplayTitle();
        DisplayBody();
        DisplayFooter();
    }

    /// <summary>
    /// Centers the given title string by padding it from left and right
    /// with empty spaces based on a constant window width.
    /// </summary>
    /// <param name="title">The string to center.</param>
    /// <returns>The centered and upper-cased title string.</returns>
    protected string GetTransformedTitle(string title)
    {
        string emptySpace = new(' ', (AppConstants.WindowWidth - title.Length)/2);
        return emptySpace + title.ToUpper() + emptySpace;
    }

    /// <summary>
    /// Draws the standardized application title block at the top of the screen.
    /// </summary>
    private void DisplayTitle()
    {
        ShowMessage($"""
                     {_headline}
                     {GetTransformedTitle(AppConstants.AppName)}
                     {_headline}
                     
                     """);  
    }

    /// <summary>
    /// Abstract method that must be implemented by derived classes to display the unique content of the page.
    /// </summary>
    protected abstract void DisplayBody();

    /// <summary>
    /// Displays a standard newline separator at the bottom of the page. Can be overridden for custom footer content.
    /// </summary>
    protected virtual void DisplayFooter() => ShowMessage("\n");
}