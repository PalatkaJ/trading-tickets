using tickets_trading.Application.Services;
namespace tickets_trading.UI.View.Menu;

public sealed record MenuItem(string Id, string Title, IService Service) { }