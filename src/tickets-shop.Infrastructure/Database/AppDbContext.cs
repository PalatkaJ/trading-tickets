using Microsoft.EntityFrameworkCore;
using tickets_shop.Domain;

namespace tickets_shop.Infrastructure.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<RegularUser> RegularUsers { get; set; }
    
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Event> Events { get; set; }
    
    public static AppDbContext Create()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=app.db");
        return new AppDbContext(optionsBuilder.Options);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<RegularUser>(UserRoles.RegularUser)
            .HasValue<Admin>(UserRoles.Admin);
        
        modelBuilder.Entity<RegularUser>()
            .HasMany(u => u.OwnedTickets)
            .WithOne(t => t.TicketOwner)
            .HasForeignKey(t => t.TicketOwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Admin>()
            .HasMany(a => a.OrganizedEvents)
            .WithOne(e => e.Organizer)
            .HasForeignKey(e => e.OrganizerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Event>()
            .HasMany(e => e.Tickets)
            .WithOne(t => t.Event)
            .HasForeignKey(t => t.EventId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}