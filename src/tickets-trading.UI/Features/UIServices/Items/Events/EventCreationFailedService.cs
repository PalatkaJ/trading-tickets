using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Items.Events;

public class EventCreationFailedService(string additional): MessageService
{
    protected override string Subtitle => "not enough tickets";
    
    protected override string Msg => 
        $"""
         Event creation failed: {additional}
         """;
}