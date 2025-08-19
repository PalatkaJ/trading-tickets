using tickets_trading.Application.Services;
using tickets_trading.UI.View;

namespace tickets_trading.UI.Services.HelpServices;

public abstract class HelpService: SimpleConsoleView, IService
{
    public void Execute() => Display();

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