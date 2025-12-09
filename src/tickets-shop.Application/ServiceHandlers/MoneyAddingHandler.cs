using Microsoft.EntityFrameworkCore;
using tickets_shop.Domain;
using tickets_shop.Domain.Users;

namespace tickets_shop.Application.ServiceHandlers;

public class MoneyAddingHandler(RegularUser user, DbContext context)
{
    public void Handle(int moneyToAdd)
    {
        user.AddMoney(moneyToAdd);
        context.SaveChanges();
    }
}