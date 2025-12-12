using System.Globalization;
using tickets_shop.Application.ServiceHandlers;
using tickets_shop.Domain.Events;
using tickets_shop.Domain.Users;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Events;

/// <summary>
/// A concrete UI service that facilitates the process of creating a new Event entity.
/// It prompts the Admin user for all necessary details (title, date, price, etc.)
/// and executes the creation logic via the EventCreationHandler.
/// </summary>
/// <param name="applicationState">The application's shared state container.</param>
public class EventCreationService(ApplicationState applicationState): UIService
{ 
    protected override string Subtitle => "event creation";
    
    /// <summary>
    /// Displays prompts for all event details, handles parsing, executes the creation handler,
    /// and displays the final confirmation or failure message.
    /// </summary>
    protected override void DisplayCore()
    {
        // Default to success confirmation; changed only if an exception is caught.
        MessageService msgService = new EventCreationConfirmationService();

        ShowMessage("""
                    --
                    You will be prompted for title, description, 
                    date and time, place, number of tickets to release
                    and price of each ticket for the event
                    --
                    
                    """);
        try
        {
            var e = new Event();
            string title = GetInput("Title: ");
            string description = GetInput("Description: ");
            DateTime date = PromptForDateTime(); // Custom method to ensure date format
            string place = GetInput("Place in any format (e.g. Malostranské náměstí, Profesní dům): ");
            
            int nrOfTickets = int.Parse(GetInput("Number of tickets to release: "));
            int price = int.Parse(GetInput("Price of one ticket (whole number): "));
            
            e.SetFields(title, description, date, place, nrOfTickets, price);

            // Execute the creation transaction using the handler
            EventCreationHandler eventCreationHandler =
                new(applicationState.EventsRepository!, 
                    (Admin)applicationState.CurrentUser!, 
                    applicationState.DbContext!);
            
            eventCreationHandler.Handle(e);
        }
        catch (Exception ex)
        {
            // Catches any errors during input parsing or handler execution
            msgService = new EventCreationFailedService(ex.Message);
        }

        msgService.DisplayContent();
    }
    
    /// <summary>
    /// Prompts the user specifically for the event date and time, requiring an exact format.
    /// </summary>
    /// <returns>A validated DateTime object.</returns>
    /// <exception cref="FormatException">Thrown if the input does not match the required format.</exception>
    private DateTime PromptForDateTime()
    {
        const string format = "yyyy-MM-dd HH:mm";
        var input = GetInput($"Time and date of event in exact format {format} (e.g. 2025-07-23 14:30): ").Trim();
        
        return DateTime.ParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None); 
    }
}