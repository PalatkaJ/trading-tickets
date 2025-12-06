using tickets_trading.Domain;

namespace tickets_trading.Application.ServiceHandlers;

public class MoneyAddingHandler(RegularUser user)
{
    public void Handle(long moneyToAdd)
    {
        user.AddMoney(moneyToAdd);
    }
}