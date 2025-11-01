using tickets_trading.UI.Core.View;
using tickets_trading.UI.Features.UIServices.UIServiceDecorators;

namespace tickets_trading.UI.Features.UIServices.Help;

public abstract class HelpService: EnterToContinueDecorator
{
    protected override string Subtitle => "HELP";
    protected abstract string Msg { get; }

    protected override void DisplayCore()
    {
        ShowMessage(Msg + "\n");
    }
}