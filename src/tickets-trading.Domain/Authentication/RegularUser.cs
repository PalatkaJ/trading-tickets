namespace tickets_trading.Domain.Authentication;

public class RegularUser : User
{
    //TODO Load info from DB
    public long MoneyLeft { get; set; }
    public ICollection<Ticket> OwnedTickets { get; private set; } = new List<Ticket>();
}