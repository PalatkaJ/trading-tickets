using System.Globalization;
using tickets_trading.Application.ServiceHandlers;
using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;

namespace tickets_trading.UI.Features.UIServices.Users;

public class MoneyAddingService(ApplicationState applicationState): UIService
{
    private readonly MoneyAddingHandler _moneyAddingHandler = new((RegularUser)applicationState.CurrentUser!);
    
    protected override string Subtitle => "add money";

    protected override void DisplayCore()
    {
        int MoneyToBeAdded = int.Parse(GetInput("Enter the amount of cash you want to insert: "));
        _moneyAddingHandler.Handle(MoneyToBeAdded);

        MoneyAddingConfirmationService confirmationService = new(MoneyToBeAdded);
        confirmationService.Execute();
    }
}