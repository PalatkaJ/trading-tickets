using System.Globalization;
using tickets_shop.Application.ServiceHandlers;
using tickets_shop.Domain.Events;
using tickets_shop.Domain.Users;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Events;

public class EventCreationService(ApplicationState applicationState): UIService
{ 
    protected override string Subtitle => "event creation";
    
    protected override void DisplayCore()
    {
        MessageService confirmation = new EventCreationConfirmationService();

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
            DateTime date = PromptForDateTime();
            string place = GetInput("Place in any format (e.g. Malostranské náměstí, Profesní dům): ");
            int nrOfTickets = int.Parse(GetInput("Number of tickets to release: "));
            int price = int.Parse(GetInput("Price of one ticket (whole number): "));
            e.SetFields(title, description, date, place, nrOfTickets, price);

            EventCreationHandler eventCreationHandler =
                new(applicationState.EventsRepository!, 
                    (Admin)applicationState.CurrentUser!, 
                    applicationState.DbContext!);
            
            eventCreationHandler.Handle(e);
        }
        catch (Exception ex)
        {
            confirmation = new EventCreationFailedService(ex.Message);
        }

        confirmation.DisplayContent();
    }
    
    private DateTime PromptForDateTime()
    {
        const string format = "yyyy-MM-dd HH:mm";
        var input = GetInput($"Time and date of event in exact format {format} (e.g. 2025-07-23 14:30): ").Trim();
        
        return DateTime.ParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None); 
    }
}