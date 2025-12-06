using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Items;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.AdminMenus;

public class AdminMainMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => "main menu";
    
    private readonly ItemDetailService<User> _adminDetailService = new();
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("Events", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.AdminEventsMenuBuilder!.Value);
        }));
        
        items.Add(CreateItem("Account Information", () =>
        {
            _adminDetailService.Execute(ApplicationState.CurrentUser!);
        }));
        items.Add(CreateNonSelectableItem());
    }
}