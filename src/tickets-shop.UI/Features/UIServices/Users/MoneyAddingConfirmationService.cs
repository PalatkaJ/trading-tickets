using tickets_shop.Domain;
using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Users;

/// <summary>
/// A concrete message service used to display a standardized confirmation message
/// to the user after money has been successfully added to their account.
/// </summary>
public class MoneyAddingConfirmationService: MessageService
{
    protected override string Subtitle =>  "money added successfully";
    
    public int Amount { get; init; }
    
    protected override string Msg => 
        $"""
         You have successfully recharged {Amount} {AppConstants.Currency} into your account,
         see more in account information tab.
         """;
}