using Microsoft.EntityFrameworkCore;
using tickets_shop.Domain.Users;

namespace tickets_shop.Application.ServiceHandlers;

/// <summary>
/// A service handler responsible for executing the business logic of adding money
/// to a RegularUser's account and persisting the change to the database.
/// </summary>
/// <param name="user">The RegularUser domain entity whose balance will be updated.</param>
/// <param name="context">The Entity Framework Core DbContext used to finalize and commit the transaction.</param>
public class MoneyAddingHandler(RegularUser user, DbContext context)
{
    /// <summary>
    /// Executes the full money adding process: updates the user's balance
    /// and saves the changes to the database. The logic could
    /// get much more complex here. 
    /// </summary>
    /// <param name="moneyToAdd">The amount of money to be added to the user's account.</param>
    public void Handle(int moneyToAdd)
    {
        user.AddMoney(moneyToAdd);
        context.SaveChanges();
    }
}