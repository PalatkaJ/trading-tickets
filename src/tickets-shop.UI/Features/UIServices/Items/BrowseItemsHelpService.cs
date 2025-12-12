using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Items;

/// <summary>
/// A generic help service that provides instructions to the user on how to interact
/// with a screen that displays a list of selectable domain entities (e.g., browsing events or tickets).
/// </summary>
/// <typeparam name="TItem">The type of the domain entity being displayed (e.g., Event, Ticket).</typeparam>
public class BrowseItemsHelpService<TItem>: HelpService
{
    /// <summary>
    /// Gets the informational message, dynamically instructing the user to select an item
    /// based on the generic type name (e.g., "Select given event title to proceed.").
    /// </summary>
    protected override string Msg => 
        $"""
         Select given {typeof(TItem).Name.ToLower()} title to proceed.
         """;
}