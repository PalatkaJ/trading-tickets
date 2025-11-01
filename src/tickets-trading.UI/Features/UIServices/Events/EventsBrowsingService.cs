using tickets_trading.Domain.Authentication;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.UIServices.UIServiceDecorators;

namespace tickets_trading.UI.Features.UIServices.Events;

public class EventsBrowsingService(ApplicationState applicationState): EnterToContinueDecorator
{
    protected override string Subtitle => "LIST OF ORGANIZED EVENTS";

    protected override void DisplayCore()
    {
        Admin admin = (Admin)applicationState.CurrentUser!;

        foreach (var e in admin.OrganizedEvents)
        {
            ShowMessage(e.ToString());
        }
    }
}