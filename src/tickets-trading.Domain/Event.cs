using tickets_trading.Domain.Authentication;

namespace tickets_trading.Domain;


// TODO change Event so the ticket cost is there and not at the ticket
public class Event
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public string? Title { get; private set; }
    
    public string? Description { get; private set; }
    public int Price { get; private set; }
    public string Currency => "Czk";

    public DateTime? Date { get; private set; }
    public string? Place { get; private set; }

    public Admin? Organizer { get; private set; }
    public Guid? OrganizerId { get; set; }

    private int _ticketsLeft; 
    public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();
    

    public override string ToString()
    {
        return $"""
                Title:        {Title ?? "N/A"}
                Description:  {Description ?? "N/A"}
                Date:         {(Date.HasValue ? Date.Value.ToString("dd MMM yyyy HH:mm") : "N/A")}
                Place:        {Place ?? "N/A"}

                Organizer:    {Organizer?.Username ?? "Unknown"}

                Tickets:      {_ticketsLeft}/{Tickets?.Count ?? 0} available
                Price:        {Price} {Currency}
                """;
    }
    
    public void SetFields(string title, string description, DateTime date, string place, 
        Admin organizer, int numberOfTickets, int price)
    {
        Title = title;
        Description = description;
        Date = date;
        Place = place;
        Organizer = organizer;
        OrganizerId = Organizer.Id;
        Price = price;
        _ticketsLeft = numberOfTickets;
        GenerateTickets(numberOfTickets);
    }
    
    private void GenerateTickets(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Ticket ticket = new();
            ticket.SetFields($"Seat-{i + 1}", this);
            Tickets.Add(ticket);
        }
    }
    
    // for EF core
    public Event() { }
}