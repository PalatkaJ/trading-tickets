using System.Globalization;
using tickets_trading.Application.ServiceHandlers;
using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Items.Events;

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
            long price = long.Parse(GetInput("Price of one ticket: "));
            e.SetFields(title, description, date, place, nrOfTickets, price);

            EventCreationHandler eventCreationHandler =
                new(applicationState.EventsRepository!, (Admin)applicationState.CurrentUser!);
            eventCreationHandler.Handle(e);
        }
        catch (Exception ex)
        {
            confirmation = new EventCreationFailedService(ex.Message);
        }

        confirmation.Execute();
    }
    
    private DateTime PromptForDateTime()
    {
        const string format = "yyyy-MM-dd HH:mm";
        var input = GetInput($"Time and date of event in format {format} (e.g. 2025-07-23 14:30): ").Trim();

        return DateTime.ParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None); 
    }
}