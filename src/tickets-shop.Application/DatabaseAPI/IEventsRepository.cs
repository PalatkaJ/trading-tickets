using tickets_shop.Domain;

namespace tickets_shop.Application.DatabaseAPI;

public interface IEventsRepository
{
    public void AddEvent(Event e);

    public IQueryable<Event> GetAllEventsWithDependencies();
    
    public Event? GetEventById(Guid id);
    
}