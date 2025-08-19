
namespace tickets_trading.Application.Services.ActionServices;

public class ExitService: IService
{
    public void Execute() => Environment.Exit(0);
}