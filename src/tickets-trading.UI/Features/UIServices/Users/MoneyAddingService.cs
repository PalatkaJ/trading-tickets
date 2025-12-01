using System.Globalization;
using tickets_trading.Application.ServiceHandlers;
using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Users;

public class MoneyAddingService(ApplicationState applicationState): UIService
{
    private readonly MoneyAddingHandler _moneyAddingHandler = new((RegularUser)applicationState.CurrentUser!);
    
    protected override string Subtitle => "add money";

    protected override void DisplayCore()
    {
        MessageService confirmationService = new MoneyAddingConfirmationService();
        try
        {
            int MoneyToBeAdded = int.Parse(GetInput("Enter the amount of cash you want to insert: "));
            _moneyAddingHandler.Handle(MoneyToBeAdded);
        }
        catch (FormatException ex)
        {
            confirmationService = new MoneyAddingFailedService("Please enter a valid decimal integer");
        }
        catch (OverflowException)
        {
            confirmationService = new MoneyAddingFailedService("Value was either too large or too small");
        }
        
        confirmationService.Execute();
    }
}