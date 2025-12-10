using tickets_shop.Domain.Tickets;

namespace tickets_shop.Domain.Users;

/// <summary>
/// Represents a regular user with capabilities to hold money and tickets
/// </summary>
public class RegularUser : User
{
    /// <summary>
    /// The amount of money (in the application's base currency) available to the user for purchases.
    /// </summary>
    public int MoneyLeft { get; private set; }

    /// <summary>
    /// A collection of tickets currently owned by the user.
    /// </summary>
    public ICollection<Ticket> OwnedTickets { get; private set; } = new List<Ticket>();

    /// <summary>
    /// Gets the role string constant defined for a Regular User.
    /// </summary>
    public override string GetRole => UserRoles.RegularUser;

    /// <summary>
    /// Checks if the user's available money is greater than or equal to the specified price.
    /// </summary>
    /// <param name="price">The cost of the item being checked.</param>
    /// <returns>True if the user can afford the price; otherwise, false.</returns>
    public bool HasEnoughMoney(int price) => MoneyLeft >= price;

    /// <summary>
    /// Removes a specified amount from the user's available money.
    /// </summary>
    /// <param name="price">The amount to remove (e.g., the cost of a purchase).</param>
    public void RemoveMoney(int price)
    {
        MoneyLeft -= price;
    }

    /// <summary>
    /// Adds a specified amount to the user's available money (e.g., for a recharge).
    /// </summary>
    /// <param name="money">The amount of money to add.</param>
    public void AddMoney(int money)
    {
        MoneyLeft += money;
    }
    
    /// <summary>
    /// Calculates the total cumulative price of all tickets currently held in the OwnedTickets collection.
    /// </summary>
    /// <returns>The total money spent on owned tickets, returned as a long to prevent overflow.</returns>
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