using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Items;

public class BrowseItemsHelpService<TItem>: HelpService
{
    protected override string Msg => 
        $"""
        Select given {typeof(TItem).Name.ToLower()} title to proceed.
        """;
}