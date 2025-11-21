namespace tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

public abstract class MessageService: EnterToContinueDecorator
{
    protected abstract string Msg { get; }

    protected override void DisplayCore()
    {
        ShowMessage(Msg);
    }
}