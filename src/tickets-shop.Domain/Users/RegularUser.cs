using tickets_shop.Domain.Tickets;

namespace tickets_shop.Domain.Users;

public class RegularUser : User
{
    public int MoneyLeft { get; private set; }
    public ICollection<Ticket> OwnedTickets { get; private set; } = new List<Ticket>();


    public bool HasEnoughMoney(int price) => MoneyLeft >= price;

    public void RemoveMoney(int price)
    {
        MoneyLeft -= price;
    }

    public void AddMoney(int money)
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
                Owned Tickets: {OwnedTickets.Count}
                Money Spent: {CalculateMoneySpent()} {AppConstants.Currency}
                """;
    }
}