using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;
using tickets_shop.Application.ServiceHandlers;

namespace tickets_shop.UI.Features.UIServices.Users;

public class MoneyAddingService(ApplicationState applicationState): UIService
{
    private readonly MoneyAddingHandler _moneyAddingHandler = new((RegularUser)applicationState.CurrentUser!);
    
    protected override string Subtitle => SiteNames.AddMoney;

    private bool TryParseAmountOfCash(string nrInString, ref long res, out MessageService msgService)
    {
        try
        {
            long moneyToBeAdded = long.Parse(nrInString);
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
            msgService = new MoneyAddingFailedService(AppMessages.NumberInvalidFormat);
            return false;
        }
        catch (OverflowException)
        {
            msgService = new MoneyAddingFailedService(AppMessages.NumberOverflow);
            return false;
        }
    }
    
    protected override void DisplayCore()
    {
        string nrInString = GetInput($"Enter the amount of {AppConstants.Currency} you want to insert: ");

        long res = 0;
        bool success = TryParseAmountOfCash(nrInString, ref res, out var confirmationService);

        if (success)
        {
            _moneyAddingHandler.Handle(res);
        }
        
        confirmationService.DisplayContent();
    }
}