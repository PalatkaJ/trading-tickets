using Microsoft.EntityFrameworkCore;
using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Domain.Events;

namespace tickets_shop.Infrastructure.Database;

/// <summary>
/// Implements the IEventsRepository contract using Entity Framework Core to
/// provide persistence and query operations for the Event domain entity.
/// </summary>
/// <param name="context">The application's database context used to interact with the data store.</param>
public class EventsRepository(AppDbContext context): IEventsRepository
{
    public void AddEvent(Event e)
    {
        context.Events.Add(e);
        context.SaveChanges();
    }
    
    public IQueryable<Event> LazyGetAllEventsWithDependencies()
    {
        return context.Events
            .Include(e => e.Organizer)
            .Include(e => e.Tickets);
    }
    
    public Event? GetEventById(Guid id) => context.Events.Find(id);
}