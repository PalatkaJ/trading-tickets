using tickets_trading.Domain.Authentication;

namespace tickets_trading.Domain;

public class Event
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public string Title { get; private set; }

    public string Description { get; private set; }

    public DateTime Date { get; private set; }
    public string Place { get; private set; }

    public Admin Organizer { get; private set; }
    public Ticket[] Tickets { get; private set; }

    public override string ToString()
    {
        return Title;
    }
    
    public void SetFields(string title, string description, DateTime date, string place, 
        Admin organizer, int numberOfTickets)
    {
        Title = title;
        Description = description;
        Date = date;
        Place = place;
        Organizer = organizer;
        Tickets = new Ticket[numberOfTickets];
    }
    
    // for EF core
    public Event() { }
}