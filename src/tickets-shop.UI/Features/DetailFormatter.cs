using tickets_shop.Domain;
using tickets_shop.Domain.Events;
using tickets_shop.Domain.Tickets;
using tickets_shop.Domain.Users;

namespace tickets_shop.UI.Features;

public static class DetailFormatter
{
    public static string PrintFormatted<TItem>(TItem item) => item switch
    {
        RegularUser ru => PrintFormattedRegularUser(ru),
        Admin a => PrintFormattedAdmin(a),
        Event e => PrintFormattedEvent(e),
        Ticket t => PrintFormattedTicket(t),
        _ => PrintFormattedUnknown(item)
    };
    
    private static string PrintFormattedBase(User user)
    {
        return $"""
                Username:     {user.Username}
                Role:         {user.GetRole}
                """;
    }
    
    private static string PrintFormattedRegularUser(RegularUser ru)
    {
        return PrintFormattedBase(ru) + $"""
                                                                        
                                                                                 
                                         Money Left: {ru.MoneyLeft} {AppConstants.Currency}
                                         Owned Tickets: {ru.OwnedTickets.Count}
                                         Money Spent: {ru.CalculateMoneySpent()} {AppConstants.Currency}
                                         """;
    }
    
    private static string PrintFormattedAdmin(Admin a)
    {
        return PrintFormattedBase(a) + $"""


                                        Managed Events: {a.OrganizedEvents?.Count ?? 0}
                                        """;
    }

    private static string PrintFormattedEvent(Event e)
    {
        return $"""
                Title:        {e.Title}

                Description:  {e.Description}
                Date:         {e.Date!.Value:dd MMM yyyy HH:mm}
                Place:        {e.Place}

                Tickets:      {e.TicketCount - e.CurrentFreeTicket}/{e.TicketCount} available
                Price:        {e.Price} {AppConstants.Currency}
                """;
    }
    
    private static string PrintFormattedTicket(Ticket ticket)
    {
        return PrintFormattedEvent(ticket.Event!) + $"\nSeat:         [Seat-{ticket.Seat}]";
    }

    private static string PrintFormattedUnknown<TItem>(TItem item)
    {
        return "Unknown type to print detail about...";
    }
}