using tickets_trading.Domain;

namespace tickets_trading.Application.ServiceHandlers;

public class EventCreationHandler
{
    public void Handle(Event e)
    {
        e.Organizer.OrganizedEvents.Add(e);
        //TODO save event to DB (loading to the shop then will be okay I guess if I load from DB)
    }
}