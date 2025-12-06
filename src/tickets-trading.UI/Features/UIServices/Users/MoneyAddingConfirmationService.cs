using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Users;

public class MoneyAddingConfirmationService: MessageService
{
    protected override string Subtitle =>  "money added successfully";

    protected override string Msg => 
        $"""
        You have successfully recharged money into your account,
        see more in account information tab.
        """;
}