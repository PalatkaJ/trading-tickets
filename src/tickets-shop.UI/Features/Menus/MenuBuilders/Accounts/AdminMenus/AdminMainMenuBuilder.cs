using tickets_shop.Domain;
using tickets_shop.Domain.Users;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_shop.UI.Features.UIServices.Items;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Accounts.AdminMenus;

public class AdminMainMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.Main;
    
    private readonly ItemDetailService<User> _adminDetailService = new();
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem(SiteNames.AdminEvents, () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.AdminEventsMenuBuilder!.Value);
        }));
        
        items.Add(CreateItem(SiteNames.AccountInfo, () =>
        {
            _adminDetailService.Execute(ApplicationState.CurrentUser!);
        }));
        items.Add(CreateNonSelectableItem());
    }
}