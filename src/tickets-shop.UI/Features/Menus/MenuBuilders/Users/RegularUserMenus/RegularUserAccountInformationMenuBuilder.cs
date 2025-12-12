using tickets_shop.Domain;
using tickets_shop.Domain.Users;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Items;
using tickets_shop.UI.Features.UIServices.Users;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.RegularUserMenus;

/// <summary>
/// The concrete menu builder for the Account Information screen for a Regular User.
/// It provides options to view account details and access the money adding service.
/// </summary>
/// <param name="applicationState">The application's shared state container.</param>
public class RegularUserAccountInformationMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.AccountInfo;
    
    // Services for displaying user details and handling money transactions.
    private readonly ItemDetailService<User> _usersDetailService = new();
    private readonly MoneyAddingService _moneyAddingService = new(applicationState);
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        // Option to display the detailed profile information for the current user.
        items.Add(CreateItem("Show Detail", () =>
        {
            _usersDetailService.Execute(ApplicationState.CurrentUser!);
        }));

        // Option to initiate the Money Adding Service workflow.
        items.Add(CreateItem(SiteNames.AddMoney, _moneyAddingService.Execute));

        items.Add(CreateNonSelectableItem()); // Separator
        
        // Option to navigate back to the Regular User Main Menu.
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserMainMenuBuilder!.Value);
        }));
    }
}