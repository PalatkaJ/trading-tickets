using Microsoft.EntityFrameworkCore;

namespace tickets_shop.Application.ServiceHandlers;

public abstract class CommitDbChangesHandler(DbContext context)
{
    protected void CommitChanges()
    {
        context.SaveChanges();
    }
}