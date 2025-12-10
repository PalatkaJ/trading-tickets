using Microsoft.EntityFrameworkCore;
using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Domain.Events;
using tickets_shop.Domain.Tickets;
using tickets_shop.Domain.Users;

namespace tickets_shop.Application.ServiceHandlers;

/// <summary>
/// A service handler responsible for the process of creating a new Event
/// entity, including generating all required Ticket entities and persisting the changes.
/// </summary>
/// <param name="eventsRepo">The repository used to save the new Event entity.</param>
/// <param name="admin">The Admin user who is organizing the event.</param>
/// <param name="context">The Entity Framework Core DbContext used to finalize and commit the transaction.</param>
public class EventCreationHandler(IEventsRepository eventsRepo, Admin admin, DbContext context)
{
    /// <summary>
    /// Creates the specified number of Ticket entities for the new Event and
    /// associates each ticket's seat number with the event.
    /// </summary>
    /// <param name="e">The Event object to which tickets will be added.</param>
    private void GenerateTickets(Event e)
    {
        for (int i = 0; i < e.TicketCount; i++)
        {
            Ticket ticket = new();
            ticket.AssociateTicketWithEvent(i + 1, e);
            e.Tickets.Add(ticket);
        }
    }
    
    /// <summary>
    /// Executes the full event creation logic: generates tickets, sets the organizer,
    /// adds the event to the organizer's collection, persists the event, and saves
    /// all changes to the database.
    /// </summary>
    /// <param name="e">The prepared Event domain entity ready for ticket generation and persistence.</param>
    public void Handle(Event e)
    {
        GenerateTickets(e);
        e.SetOrganizer(admin);
        admin.OrganizedEvents.Add(e);
        eventsRepo.AddEvent(e);
        
        context.SaveChanges();
    }
}