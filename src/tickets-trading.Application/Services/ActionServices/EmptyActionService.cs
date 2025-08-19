namespace tickets_trading.Application.Services.ActionServices;

public class EmptyActionService(Action action): IService
{
    public void Execute() => action();
}