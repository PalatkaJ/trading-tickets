using tickets_shop.Domain.Events;
using tickets_shop.Domain.Users;

namespace tickets_shop.Domain.Tickets;

/// <summary>
/// Represents a single purchasable ticket, uniquely identified and tied to a specific
/// event and (eventually) an owner.
/// </summary>
public class Ticket
{
    /// <summary>
    /// The unique identifier for this ticket instance. Automatically generated upon creation.
    /// </summary>
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    /// <summary>
    /// The specific seat number associated with this ticket for the event.
    /// </summary>
    public int Seat { get; set; }
    
    /// <summary>
    /// The navigation property linking to the user who currently owns this ticket (optional).
    /// </summary>
    public RegularUser? TicketOwner { get; set; }
    
    /// <summary>
    /// The foreign key to the owner of the ticket. Nullable if the ticket is unsold.
    /// The ID is needed by the EF Core to map db relationship.
    /// </summary>
    public Guid? TicketOwnerId { get; set; }
    
    /// <summary>
    /// The navigation property linking to the event this ticket belongs to.
    /// </summary>
    public Event? Event { get; set; }
    
    /// <summary>
    /// The foreign key to the event this ticket grants access to.
    /// The ID is needed by the EF Core to map db relationship.
    /// </summary>
    public Guid? EventId { get; set; }
    
    /// <summary>
    /// Sets the seat number and associates the ticket with a specific event.
    /// </summary>
    /// <param name="seat">The seat number for the ticket.</param>
    /// <param name="e">The event object the ticket belongs to.</param>
    public void AssociateTicketWithEvent(int seat, Event e)
    {
        Seat = seat;
        Event = e;
        EventId = e.Id;
    }

    /// <summary>
    /// Assigns ownership of the ticket to a specific RegularUser.
    /// </summary>
    /// <param name="owner">The user taking ownership of the ticket.</param>
    public void SetOwner(RegularUser owner)
    {
        TicketOwner = owner;
        TicketOwnerId = owner.Id;
    }
    
    /// <summary>
    /// Parameterless constructor required by Entity Framework Core to create objects from database records.
    /// </summary>
    public Ticket() { }
}