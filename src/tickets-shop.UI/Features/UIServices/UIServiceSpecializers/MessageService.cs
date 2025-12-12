namespace tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

/// <summary>
/// Provides an abstract base class for all UI services that display a simple,
/// static message to the user. It inherits the Enter-to-continue functionality
/// from the decorator class to ensure the message is readable before the screen changes.
/// </summary>
public abstract class MessageService: EnterToContinueDecorator
{
    /// <summary>
    /// Abstract property to provide
    /// the specific content of the message to be displayed.
    /// </summary>
    protected abstract string Msg { get; }

    /// <summary>
    /// Implements the core display logic by simply writing the defined message string to the console.
    /// </summary>
    protected override void DisplayCore()
    {
        ShowMessage(Msg);
    }
}