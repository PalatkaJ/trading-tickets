using tickets_shop.Domain;

namespace tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

public abstract class HelpService: MessageService
{
    protected override string Subtitle => SiteNames.Help;
}