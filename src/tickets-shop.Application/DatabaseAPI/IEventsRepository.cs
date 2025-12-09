using tickets_shop.Domain.Events;

namespace tickets_shop.Application.DatabaseAPI;

public interface IEventsRepository
{
    public void AddEvent(Event e);

    public IQueryable<Event> LazyGetAllEventsWithDependencies();
    
    public Event? GetEventById(Guid id);
}