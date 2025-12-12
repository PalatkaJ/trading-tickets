using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;
using tickets_shop.Application.ServiceHandlers;
using tickets_shop.Domain.Users;

namespace tickets_shop.UI.Features.UIServices.Users;

/// <summary>
/// A concrete UI service that facilitates the process of allowing a RegularUser to add money to their account.
/// It handles user input and passes the result to money adding handler
/// </summary>
/// <param name="applicationState">The application's shared state container, providing access to the current user and dependencies.</param>
public class MoneyAddingService(ApplicationState applicationState): UIService
{
    protected override string Subtitle => SiteNames.AddMoney;

    /// <summary>
    /// Attempts to parse the user's string input into a valid positive integer amount of currency.
    /// </summary>
    /// <param name="nrInString">The raw string input from the user.</param>
    /// <param name="res">A reference parameter that holds the parsed integer amount if successful.</param>
    /// <param name="msgService">The appropriate message service (confirmation or failure) to display next.</param>
    /// <returns>True if parsing and validation succeed; otherwise, false.</returns>
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
    
    /// <summary>
    /// Displays the input prompt, collects user input, validates it, executes the transaction handler,
    /// and displays the outcome message.
    /// </summary>
    protected override void DisplayCore()
    {
        string nrInString = GetInput($"Enter the amount of {AppConstants.Currency} you want to insert: ");

        int res = 0;
        bool success = TryParseAmountOfCash(nrInString, ref res, out var confirmationService);

        if (success)
        {
            // Creates and executes the transaction logic handler
            MoneyAddingHandler moneyAddingHandler = 
                new((RegularUser)applicationState.CurrentUser!, 
                    applicationState.DbContext!);
            
            moneyAddingHandler.Handle(res);
        }
        
        // Displays the confirmation or failure message to the user
        confirmationService.DisplayContent();
    }
}