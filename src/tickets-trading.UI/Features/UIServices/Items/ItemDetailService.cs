using System.Runtime.InteropServices.ComTypes;
using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Items;

public class ItemDetailService<TItem>: MessageService
{
    private TItem? _item;
    
    public void Execute(TItem item)
    {
        _item = item;
        Execute();
    }
    
    protected override string Subtitle => $"{typeof(TItem).Name.ToLower()} detail";

    protected override string Msg => _item!.ToString()!;
}