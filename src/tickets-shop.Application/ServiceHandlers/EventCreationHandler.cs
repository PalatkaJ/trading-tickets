using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Domain;

namespace tickets_shop.Application.ServiceHandlers;

public class EventCreationHandler(IEventsRepository eventsRepo, Admin admin)
{
    public void Handle(Event e)
    {
        e.SetOrganizer(admin);
        admin.OrganizedEvents.Add(e);
        eventsRepo.AddEvent(e);
    }
}