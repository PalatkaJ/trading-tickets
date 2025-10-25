using tickets_trading.Application.Common;
using tickets_trading.UI.Core.View;

namespace tickets_trading.UI.Features.Help;

public abstract class HelpService: ConsoleViewBase, IService
{
    public void Execute() => DisplayContent();

    protected abstract string Msg { get; }

    protected override void DisplayBody()
    {
        ShowMessage("HELP\n");
        ShowMessage(Msg + "\n");
    }

    protected override void DisplayFooter()
    {
        base.DisplayFooter();
        ShowMessage("Press Enter to return to the previous page...");
        GetInput();
    }
}