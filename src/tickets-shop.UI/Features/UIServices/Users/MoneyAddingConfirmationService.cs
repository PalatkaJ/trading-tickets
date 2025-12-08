using tickets_shop.Domain;
using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Users;

public class MoneyAddingConfirmationService: MessageService
{
    protected override string Subtitle =>  "money added successfully";

    public long Amount { get; init; }

    protected override string Msg => 
        $"""
        You have successfully recharged {Amount} {AppConstants.Currency} into your account,
        see more in account information tab.
        """;
}