using tickets_trading.UI.Core.View;

namespace tickets_trading.UI.Features.Menus.MenuView;

public class MenuView: ConsoleViewBase, IMenuView
{
    public IReadOnlyList<MenuItem>? Options { private get; set; }
    
    protected override void DisplayBody()
    {
        if (Options is null) throw new ArgumentNullException(nameof(Options));

        foreach (var menuItem in Options)
        {
            ShowMessage(menuItem + "\n");
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