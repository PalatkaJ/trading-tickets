using Microsoft.EntityFrameworkCore;
using tickets_trading.Application.DatabaseAPI;
using tickets_trading.Domain;

namespace tickets_trading.Infrastructure.Database;

public class EventsRepository(AppDbContext context): IEventsRepository
{
    public void AddEvent(Event e)
    {
        context.Attach(e.Organizer!);
        context.Events.Add(e);
        context.SaveChanges();
    }

    public IQueryable<Event> GetAllEventsWithDependencies()
    {
        return context.Events
            .Include(e => e.Organizer)
            .Include(e => e.Tickets);
    }
    
    public Event? GetEventById(Guid id) => context.Events.Find(id);
    
}