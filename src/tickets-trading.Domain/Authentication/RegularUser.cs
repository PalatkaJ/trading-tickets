namespace tickets_trading.Domain.Authentication;

public class RegularUser : User
{
    public long MoneyLeft { get; private set; }
    public ICollection<Ticket> OwnedTickets { get; private set; } = new List<Ticket>();


    public bool HasEnoughMoney(int price) => MoneyLeft >= price;

    public void Buy(int price)
    {
        MoneyLeft -= price;
    }
}