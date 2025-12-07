using tickets_shop.UI.Features.Menus;
using tickets_shop.UI.Features.Menus.MenuBuilders;

namespace tickets_shop.UI.Features.UIServices.Menu;

public class MenuService: UIService
{
    private IReadOnlyList<MenuItem>? _options;
    
    public MenuBuilderTemplate? MenuBuilder { get; set; }
    
    protected override string Subtitle => MenuBuilder!.Title;
    
    protected override void DisplayCore()
    {
        _options = MenuBuilder!.BuildMenu();
        
        bool first = true;        
        foreach (var menuItem in _options)
        {
            if (!first) ShowMessage("\n");
            ShowMessage(menuItem.ToString());
            first = false;
        }
    }

    public MenuItem ChooseOption()
    {
        if (_options is null) throw new ArgumentNullException(nameof(_options));

        bool invalidOption = false;
        
        while (true)
        {
            DisplayContent();
            
            if (invalidOption) ShowMessage("Invalid option. Try again.\n");
            
            var optionId = GetInput("Select: ");
            try
            {
                var item = _options.First(o => o.Id == optionId);
                return item;
            }
            catch (InvalidOperationException)
            {
                invalidOption = true;   
            }
        }
    }
}