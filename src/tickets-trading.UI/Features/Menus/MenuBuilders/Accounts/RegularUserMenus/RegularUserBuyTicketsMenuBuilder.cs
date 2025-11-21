using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Events;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.RegularUserMenus;

public class RegularUserBuyTicketsMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("Browse Available Events", () => { }));
        items.Add(CreateItem("Back", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.RegularUserMainMenuBuilder?.Value;
        } ));
    }
}