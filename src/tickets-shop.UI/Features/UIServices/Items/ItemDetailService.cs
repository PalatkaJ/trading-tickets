using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Items;

public class ItemDetailService<TItem>: MessageService
{
    private TItem? _item;
    
    public void Execute(TItem item)
    {
        _item = item;
        DisplayContent();
    }
    
    protected override string Subtitle => $"{typeof(TItem).Name.ToLower()} detail";

    //protected override string Msg => _item!.ToString()!;
    protected override string Msg => DetailFormatter.PrintFormatted(_item);
}