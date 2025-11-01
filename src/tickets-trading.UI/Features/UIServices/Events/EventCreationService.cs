using System.Globalization;
using tickets_trading.Application.ServiceHandlers;
using tickets_trading.Domain;
using tickets_trading.Domain.Authentication;
using tickets_trading.UI.Core.Startup;

namespace tickets_trading.UI.Features.UIServices.Events;

public class EventCreationService(ApplicationState applicationState): UIService
{
    private readonly EventCreationHandler _eventCreationHandler = new();
    
    protected override string Subtitle => "EVENT CREATION";

    protected override void DisplayCore()
    {
        var e = new Event();
        string title = GetInput("Title: ");
        string description = GetInput("Description: ");
        DateTime date = PromptForDateTime();
        string place = GetInput("Place in any format (e.g. Malostranské náměstí, Profesní dům): ");
        int nrOfTickets = int.Parse(GetInput("Number of tickets to release: "));
        e.SetFields(title, description, date,place, (Admin)applicationState.CurrentUser!, nrOfTickets);
        
        _eventCreationHandler.Handle(e);
    }
    
    private DateTime PromptForDateTime()
    {
        const string format = "yyyy-MM-dd HH:mm";
        var input = GetInput($"Time and date of event in format {format} (e.g. 2025-07-23 14:30): ");

        return DateTime.ParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None); 
    }
}