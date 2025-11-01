using tickets_trading.Application.DatabaseAPI;
using tickets_trading.Domain;

namespace tickets_trading.Application.ServiceHandlers;

public class EventCreationHandler(IEventsRepository eventsRepo)
{
    public void Handle(Event e)
    {
        e.Organizer.OrganizedEvents.Add(e);
        eventsRepo.AddEvent(e);
    }
}