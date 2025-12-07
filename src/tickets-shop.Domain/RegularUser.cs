namespace tickets_shop.Domain;

public class RegularUser : User
{
    public long MoneyLeft { get; private set; }
    public ICollection<Ticket> OwnedTickets { get; private set; } = new List<Ticket>();


    public bool HasEnoughMoney(long price) => MoneyLeft >= price;

    public void RemoveMoney(long price)
    {
        MoneyLeft -= price;
    }

    public void AddMoney(long money)
    {
        MoneyLeft += money;
    }

    private long CalculateMoneySpent()
    {
        long res = 0;
        foreach (var t in OwnedTickets)
        {
            res += t.Event!.Price;
        }

        return res;
    }

    protected override string GetRole => UserRoles.RegularUser;

    public override string ToString()
    {
        return base.ToString() + $"""
                               
                                  
                Money Left: {MoneyLeft} {AppConstants.Currency}
                Owned Tickets: {OwnedTickets?.Count ?? 0}
                Money Spent: {CalculateMoneySpent()} {AppConstants.Currency}
                """;
    }
}