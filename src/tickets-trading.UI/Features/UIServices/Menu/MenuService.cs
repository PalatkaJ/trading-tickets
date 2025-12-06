using tickets_trading.UI.Features.Menus.MenuBuilders;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.UIServices.Menu;

public class MenuService: UIService, IMenuView
{
    public IReadOnlyList<MenuItem>? Options { private get; set; }
    
    public MenuBuilderTemplate? MenuBuilder { get; set; }
    
    protected override string Subtitle => MenuBuilder!.Title;
    
    protected override void DisplayCore()
    {
        Options = MenuBuilder!.BuildMenu();
        
        bool first = true;        
        foreach (var menuItem in Options)
        {
            if (!first) ShowMessage("\n");
            ShowMessage(menuItem.ToString());
            first = false;
        }
    }

    public MenuItem ChooseOption()
    {
        if (Options is null) throw new ArgumentNullException(nameof(Options));

        bool invalidOption = false;
        
        while (true)
        {
            DisplayContent();
            
            if (invalidOption) ShowMessage("Invalid option. Try again.\n");
            
            var optionId = GetInput("Select: ");
            try
            {
                var item = Options.First(o => o.Id == optionId);
                return item;
            }
            catch (InvalidOperationException)
            {
                invalidOption = true;   
            }
        }
    }
}