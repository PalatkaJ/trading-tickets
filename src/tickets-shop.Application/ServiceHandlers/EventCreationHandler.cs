using Microsoft.EntityFrameworkCore;
using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Domain;
using tickets_shop.Domain.Events;
using tickets_shop.Domain.Users;

namespace tickets_shop.Application.ServiceHandlers;

public class EventCreationHandler(IEventsRepository eventsRepo, Admin admin, DbContext context): CommitDbChangesHandler(context)
{
    public void Handle(Event e)
    {
        e.SetOrganizer(admin);
        admin.OrganizedEvents.Add(e);
        eventsRepo.AddEvent(e);
        
        CommitChanges();
    }
}