namespace tickets_trading.Domain;

public class RegularUser : User
{
    public long MoneyLeft { get; private set; }
    public ICollection<Ticket> OwnedTickets { get; private set; } = new List<Ticket>();


    public bool HasEnoughMoney(int price) => MoneyLeft >= price;

    public void Buy(int price)
    {
        MoneyLeft -= price;
    }

    public void AddMoney(int money)
    {
        MoneyLeft += money;
    }

    private int CalculateMoneySpent()
    {
        int res = 0;
        foreach (var t in OwnedTickets)
        {
            res += t.Event!.Price;
        }

        return res;
    }

    protected override string GetRole => "Regular User";

    public override string ToString()
    {
        int totalMoneySpent = CalculateMoneySpent();
        return base.ToString() + $"""
                               
                                  
                Money Left: {MoneyLeft}
                Owned Tickets: {OwnedTickets?.Count ?? 0}
                Money Spent: {totalMoneySpent}
                """;
    }
}