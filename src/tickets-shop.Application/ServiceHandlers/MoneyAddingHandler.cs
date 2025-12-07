using tickets_shop.Domain;

namespace tickets_shop.Application.ServiceHandlers;

public class MoneyAddingHandler(RegularUser user)
{
    public void Handle(long moneyToAdd)
    {
        user.AddMoney(moneyToAdd);
    }
}