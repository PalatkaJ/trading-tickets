using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Users;

public class MoneyAddingConfirmationService(int amount): MessageService
{
    protected override string Subtitle => "money added successfully";

    protected override string Msg => 
        $"""
        You have successfully added {amount} cash into your account.
        """;
}