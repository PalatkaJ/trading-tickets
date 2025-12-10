using tickets_shop.Domain.Events;

namespace tickets_shop.Application.DatabaseAPI;

/// <summary>
/// Defines the contract for persistence operations related to the Event entity.
/// </summary>
public interface IEventsRepository
{
    /// <summary>
    /// Adds a new Event entity to the database context.
    /// </summary>
    /// <param name="e">The Event object to be added.</param>
    public void AddEvent(Event e);

    /// <summary>
    /// Returns an IQueryable collection of all Event entities.
    /// This method performs Lazy Loading by default.
    /// (IQueryable inherits from IEnumerable)
    /// </summary>
    /// <returns>An IQueryable capable of querying the database.</returns>
    public IQueryable<Event> LazyGetAllEventsWithDependencies();
    
    /// <summary>
    /// Retrieves a single Event entity using its unique identifier.
    /// </summary>
    /// <param name="id">The GUID of the event to retrieve.</param>
    /// <returns>The Event object, or null if not found.</returns>
    public Event? GetEventById(Guid id);
}