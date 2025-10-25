using tickets_trading.Domain.Authentication;
using tickets_trading.UI.Features.Menus.MenuBuilders;

namespace tickets_trading.UI.Core.Startup;

public class ApplicationState
{
    public bool Running = true;
    
    public User? CurrentUser;
    public IMenuBuilder? MenuBuilder;
}