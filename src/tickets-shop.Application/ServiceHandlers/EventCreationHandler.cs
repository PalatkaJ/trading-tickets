using Microsoft.EntityFrameworkCore;
using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Domain;
using tickets_shop.Domain.Events;
using tickets_shop.Domain.Tickets;
using tickets_shop.Domain.Users;

namespace tickets_shop.Application.ServiceHandlers;

public class EventCreationHandler(IEventsRepository eventsRepo, Admin admin, DbContext context)
{
    private void GenerateTickets(Event e)
    {
        for (int i = 0; i < e.TicketCount; i++)
        {
            Ticket ticket = new();
            ticket.SetFields(i + 1, e);
            e.Tickets.Add(ticket);
        }
    }
    
    public void Handle(Event e)
    {
        GenerateTickets(e);
        e.SetOrganizer(admin);
        admin.OrganizedEvents.Add(e);
        eventsRepo.AddEvent(e);
        
        context.SaveChanges();
    }
}