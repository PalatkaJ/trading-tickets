using tickets_shop.Domain;
using tickets_shop.Domain.Events;
using tickets_shop.Domain.Tickets;
using tickets_shop.Domain.Users;

namespace tickets_shop.UI.Features;

/// <summary>
/// A static utility class responsible for taking core domain entities
/// and transforming them into formatted, human-readable string outputs
/// for display in the console user interface.
/// </summary>
public static class DetailFormatter
{
    /// <summary>
    /// Dispatches the item to the correct type-specific formatting method.
    /// Uses pattern matching (the C# 'switch' expression) for type checking.
    /// </summary>
    /// <typeparam name="TItem">The type of the item to format (User, Event, Ticket, etc.).</typeparam>
    /// <param name="item">The domain entity instance to format.</param>
    /// <returns>A formatted, multi-line string representation of the item.</returns>
    public static string PrintFormatted<TItem>(TItem item) => item switch
    {
        RegularUser ru => PrintFormattedRegularUser(ru),
        Admin a => PrintFormattedAdmin(a),
        Event e => PrintFormattedEvent(e),
        Ticket t => PrintFormattedTicket(t),
        _ => PrintFormattedUnknown(item)
    };
    
    /// <summary>
    /// Formats the common fields inherited from the User base class.
    /// </summary>
    private static string PrintFormattedBase(User user)
    {
        return $"""
                Username:     {user.Username}
                Role:         {user.GetRole}
                """;
    }
    
    /// <summary>
    /// Formats detailed information specific to a RegularUser.
    /// </summary>
    private static string PrintFormattedRegularUser(RegularUser ru)
    {
        return PrintFormattedBase(ru) + $"""
                                                                        
                                                                                 
                                         Money Left: {ru.MoneyLeft} {AppConstants.Currency}
                                         Owned Tickets: {ru.OwnedTickets.Count}
                                         Money Spent: {ru.CalculateMoneySpent()} {AppConstants.Currency}
                                         """;
    }
    
    /// <summary>
    /// Formats detailed information specific to an Admin.
    /// </summary>
    private static string PrintFormattedAdmin(Admin a)
    {
        return PrintFormattedBase(a) + $"""


                                        Managed Events: {a.OrganizedEvents?.Count ?? 0}
                                        """;
    }

    /// <summary>
    /// Formats detailed information about an Event.
    /// </summary>
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
    
    /// <summary>
    /// Formats information about a Ticket which is simply its associated Event detail and seat number.
    /// </summary>
    private static string PrintFormattedTicket(Ticket ticket)
    {
        return PrintFormattedEvent(ticket.Event!) + $"\nSeat:         [Seat-{ticket.Seat}]";
    }

    /// <summary>
    /// Returns a message for any entity type that is not explicitly handled by the formatter.
    /// </summary>
    private static string PrintFormattedUnknown<TItem>(TItem item)
    {
        return "Unknown type to print detail about...";
    }
}