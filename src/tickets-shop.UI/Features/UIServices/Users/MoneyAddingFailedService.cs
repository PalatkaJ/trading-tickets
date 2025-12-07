using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Users;

public class MoneyAddingFailedService(string additional): MessageService
{
    protected override string Subtitle => "adding money failed";

    protected override string Msg => 
        $"""
        Adding money failed: {additional}
        """;
}