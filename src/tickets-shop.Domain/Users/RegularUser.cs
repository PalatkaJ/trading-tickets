using tickets_shop.Domain.Tickets;

namespace tickets_shop.Domain.Users;

public class RegularUser : User
{
    public int MoneyLeft { get; private set; }
    public ICollection<Ticket> OwnedTickets { get; private set; } = new List<Ticket>();

    public override string GetRole => UserRoles.RegularUser;
    
    public bool HasEnoughMoney(int price) => MoneyLeft >= price;

    public void RemoveMoney(int price)
    {
        MoneyLeft -= price;
    }

    public void AddMoney(int money)
    {
        MoneyLeft += money;
    }
    
    public long CalculateMoneySpent()
    {
        long res = 0;
        foreach (var t in OwnedTickets)
        {
            res += t.Event!.Price;
        }

        return res;
    }
}