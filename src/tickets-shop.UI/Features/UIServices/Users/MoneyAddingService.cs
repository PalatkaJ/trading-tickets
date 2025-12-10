using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;
using tickets_shop.Application.ServiceHandlers;
using tickets_shop.Domain.Users;

namespace tickets_shop.UI.Features.UIServices.Users;

public class MoneyAddingService(ApplicationState applicationState): UIService
{
    protected override string Subtitle => SiteNames.AddMoney;

    private bool TryParseAmountOfCash(string nrInString, ref int res, out MessageService msgService)
    {
        try
        {
            int moneyToBeAdded = int.Parse(nrInString);
            if (moneyToBeAdded < 0) throw new InvalidOperationException();
            res = moneyToBeAdded;
            msgService =  new MoneyAddingConfirmationService
            {
                Amount = moneyToBeAdded
            };
            return true;
        }
        catch (Exception ex) when (ex is FormatException || ex is InvalidOperationException)
        {
            msgService = new MoneyAddingFailedService(ErrorMessages.NumberInvalidFormat);
            return false;
        }
        catch (OverflowException)
        {
            msgService = new MoneyAddingFailedService(ErrorMessages.NumberOverflow);
            return false;
        }
    }
    
    protected override void DisplayCore()
    {
        string nrInString = GetInput($"Enter the amount of {AppConstants.Currency} you want to insert: ");

        int res = 0;
        bool success = TryParseAmountOfCash(nrInString, ref res, out var confirmationService);

        if (success)
        {
            MoneyAddingHandler moneyAddingHandler = 
                new((RegularUser)applicationState.CurrentUser!, 
                    applicationState.DbContext!);
            
            moneyAddingHandler.Handle(res);
        }
        
        confirmationService.DisplayContent();
    }
}