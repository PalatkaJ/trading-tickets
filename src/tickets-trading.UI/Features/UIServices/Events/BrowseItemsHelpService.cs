using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Events;

public class BrowseItemsHelpService<TItem>: HelpService
{
    protected override string Msg => 
        $"""
        Select given {typeof(TItem).Name.ToLower()} title to display detailed information about it
        """;
}