using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Users;

public class MoneyAddingFailedService(string additional): MessageService
{
    protected override string Subtitle => "adding money failed";

    protected override string Msg => 
        $"""
        Adding money failed: {additional}
        """;
}