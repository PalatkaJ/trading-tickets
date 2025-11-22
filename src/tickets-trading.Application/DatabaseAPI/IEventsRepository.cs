using tickets_trading.Domain;

namespace tickets_trading.Application.DatabaseAPI;

public interface IEventsRepository
{
    public void AddEvent(Event e);

    public IQueryable<Event> GetAllEventsWithDependencies();
    
    public Event? GetEventById(Guid id);
}