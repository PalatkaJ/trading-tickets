using tickets_trading.Application.DatabaseAPI;
using tickets_trading.Domain;
using Microsoft.EntityFrameworkCore;

namespace tickets_trading.Application.ServiceHandlers;

public class MoneyAddingHandler(RegularUser user)
{
    public void Handle(int moneyToAdd)
    {
        user.AddMoney(moneyToAdd);
    }
}