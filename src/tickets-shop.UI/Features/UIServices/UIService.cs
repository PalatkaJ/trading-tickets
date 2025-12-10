using tickets_shop.Domain;
using tickets_shop.UI.Core.InputOutput;

namespace tickets_shop.UI.Features.UIServices;

public abstract class UIService: ConsoleIOTemplate
{
    private readonly string _subtitleLine = new(AppConstants.SubTitleBoarder, AppConstants.WindowWidth);
    protected abstract string Subtitle { get; }

    public virtual void Execute() => DisplayContent();
    
    private void DisplaySubtitle()
    {
        ShowMessage($"""
                     {GetTransformedTitle(Subtitle)}
                     {_subtitleLine}
                     
                     """);   
    }
    
    protected override void DisplayBody()
    {
        DisplaySubtitle();
        DisplayCore();
        ShowMessage("\n");
    }

    protected abstract void DisplayCore();
}