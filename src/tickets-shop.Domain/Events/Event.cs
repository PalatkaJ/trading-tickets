using tickets_shop.Domain.Tickets;
using tickets_shop.Domain.Users;

namespace tickets_shop.Domain.Events;

/// <summary>
/// Represents an event in the system, detailing its schedule, location, pricing,
/// organizer, and associated tickets.
/// </summary>
public class Event
{
    /// <summary>
    /// The unique identifier for this event instance. Automatically generated upon creation.
    /// </summary>
    public Guid Id { get; private set; } = Guid.NewGuid();

    /// <summary>
    /// The public name of the event.
    /// </summary>
    public string? Title { get; private set; }

    /// <summary>
    /// A detailed summary of what the event is about.
    /// </summary>
    public string? Description { get; private set; }
    
    /// <summary>
    /// The fixed price of a single ticket for this event (in the application's base currency).
    /// </summary>
    public int Price { get; private set; }

    /// <summary>
    /// The date and time when the event will take place.
    /// </summary>
    public DateTime? Date { get; private set; }
    
    /// <summary>
    /// The physical location where the event is hosted.
    /// </summary>
    public string? Place { get; private set; }

    /// <summary>
    /// The navigation property linking to the Admin user who organized this event.
    /// </summary>
    public Admin? Organizer { get; private set; }
    
    /// <summary>
    /// The foreign key to the organizing Admin. Required by EF Core.
    /// </summary>
    public Guid? OrganizerId { get; private set; }

    /// <summary>
    /// Tracks the index of the next available ticket (which seats have been allocated).
    /// </summary>
    public int CurrentFreeTicket { get; private set; }
    
    /// <summary>
    /// The total capacity of the event (the maximum number of tickets available).
    /// We use a property and not Tickets.Count because we do not have to load
    /// all tickets from db to say how many were created (that is helpful when
    /// we show event detail.)
    /// </summary>
    public int TicketCount { get; private set; }

    /// <summary>
    /// A collection of all tickets associated with this event, both sold and unsold.
    /// </summary>
    public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();
    
    /// <summary>
    /// Initializes the core details of the event.
    /// </summary>
    /// <param name="title">The public title of the event.</param>
    /// <param name="description">The event summary.</param>
    /// <param name="date">The date and time of the event.</param>
    /// <param name="place">The location of the event.</param>
    /// <param name="numberOfTickets">The total ticket capacity.</param>
    /// <param name="price">The price per ticket.</param>
    public void SetFields(string title, string description, DateTime date, string place, int numberOfTickets, int price)
    {
        Title = title;
        Description = description;
        Date = date;
        Place = place;
        Price = price;
        CurrentFreeTicket = 0;
        TicketCount = numberOfTickets;
    }

    /// <summary>
    /// Assigns the organizing Admin to the event.
    /// </summary>
    /// <param name="admin">The administrator object.</param>
    public void SetOrganizer(Admin admin)
    {
        Organizer = admin;
        OrganizerId = admin.Id;
    }

    /// <summary>
    /// Checks if the requested number of tickets can be fulfilled based on current availability.
    /// </summary>
    /// <param name="nrOfTickets">The number of tickets requested by the user.</param>
    /// <returns>True if the request is within the available ticket count; otherwise, false.</returns>
    public bool TicketsAreAvailable(int nrOfTickets) => CurrentFreeTicket + nrOfTickets - 1 < TicketCount;

    /// <summary>
    /// Retrieves a sequential range of available tickets and increments the <see cref="CurrentFreeTicket"/> counter.
    /// </summary>
    /// <param name="nr">The number of tickets to retrieve.</param>
    /// <returns>A list of available Ticket objects ready to be assigned an owner.</returns>
    public List<Ticket> GetRangeOfFreeTickets(int nr)
    {
        var range = new Range(CurrentFreeTicket, CurrentFreeTicket+nr);
        var toReturn =  Tickets.Take(range).ToList();
        CurrentFreeTicket += nr;
        
        return toReturn;
    }
    
    /// <summary>
    /// Parameterless constructor required by Entity Framework Core to create objects from database records.
    /// </summary>
    public Event() { }
}