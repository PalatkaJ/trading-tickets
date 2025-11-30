using tickets_trading.Application.DatabaseAPI;
using tickets_trading.Domain;

namespace tickets_trading.Application.ServiceHandlers;

public class EventCreationHandler(IEventsRepository eventsRepo, Admin admin)
{
    public void Handle(Event e)
    {
        e.SetOrganizer(admin);
        admin.OrganizedEvents.Add(e);
        eventsRepo.AddEvent(e);
    }
}