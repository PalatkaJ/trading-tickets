using tickets_shop.Domain;
using tickets_shop.Domain.Users;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Items;
using tickets_shop.UI.Features.UIServices.Users;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.RegularUserMenus;

public class RegularUserAccountInformationMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.AccountInfo;
    
    private readonly ItemDetailService<User> _usersDetailService = new();
    private readonly MoneyAddingService _moneyAddingService = new(applicationState);
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("Show Detail", () =>
        {
            _usersDetailService.Execute(ApplicationState.CurrentUser!);
        }));
        items.Add(CreateItem(SiteNames.AddMoney, _moneyAddingService.DisplayContent));
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserMainMenuBuilder!.Value);
        }));
    }
}