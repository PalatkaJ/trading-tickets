using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Items;

/// <summary>
/// A generic UI service responsible for displaying the detailed information
/// of any specified domain entity type (TItem).
/// </summary>
/// <typeparam name="TItem">The type of the domain entity whose details are to be displayed (e.g., Event, Admin).</typeparam>
public class ItemDetailService<TItem>: MessageService
{
    private TItem? _item;
    
    /// <summary>
    /// Executes the display of the service, setting the item whose details should be shown.
    /// </summary>
    /// <param name="item">The domain entity instance to display.</param>
    public void Execute(TItem item)
    {
        _item = item;
        DisplayContent();
    }
    
    /// <summary>
    /// Gets the subtitle for the screen, dynamically named based on the generic type (e.g., "event detail").
    /// </summary>
    protected override string Subtitle => $"{typeof(TItem).Name.ToLower()} detail";
    
    /// <summary>
    /// Gets the formatted message content by delegating the string generation to the static DetailFormatter utility.
    /// </summary>
    protected override string Msg => DetailFormatter.PrintFormatted(_item);
}