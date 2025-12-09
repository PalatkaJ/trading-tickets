using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Events;

public class EventCreationConfirmationService: MessageService
{
    protected override string Subtitle => "creation successful";

    protected override string Msg => 
        """
        Event was created successfully, you can check it out by browsing all events
        that you have already created.
        """;
}