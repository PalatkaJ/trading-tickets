using Microsoft.EntityFrameworkCore;
using tickets_shop.Domain;
using tickets_shop.Domain.Events;
using tickets_shop.Domain.Tickets;
using tickets_shop.Domain.Users;

namespace tickets_shop.Infrastructure.Database;

/// <summary>
/// The primary DbContext for the application, representing the session with the database.
/// It maps domain entities to database tables and configures entity relationships.
/// </summary>
/// <param name="options">The options required to configure the context.</param>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Represents the collection of all User entities (including Admins and RegularUsers).
    /// </summary>
    public DbSet<User> Users { get; set; }
    
    /// <summary>
    /// Represents the collection of Ticket entities.
    /// </summary>
    public DbSet<Ticket> Tickets { get; set; }
    
    /// <summary>
    /// Represents the collection of Event entities.
    /// </summary>
    public DbSet<Event> Events { get; set; }
    
    /// <summary>
    /// A factory method to create an instance of AppDbContext configured to use SQLite.
    /// </summary>
    /// <returns>A new instance of AppDbContext.</returns>
    public static AppDbContext Create()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=app.db");
        return new AppDbContext(optionsBuilder.Options);
    }

    /// <summary>
    /// Configures the User hierarchy to use just one table and distinguish roles
    /// based on the string 'Discriminator' column.
    /// </summary>
    private void OnModelCreatingSetUsersDiscriminator(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<RegularUser>(UserRoles.RegularUser)
            .HasValue<Admin>(UserRoles.Admin);
    }
    
    /// <summary>
    /// Configures the one-to-many relationship between RegularUser and Ticket (OwnedTickets).
    /// Sets a cascade delete behavior (if the user gets deleted so do the tickets connected to that user).
    /// </summary>
    private void OnModelCreatingSetRegularUsersDependencies(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegularUser>()
            .HasMany(u => u.OwnedTickets)
            .WithOne(t => t.TicketOwner)
            .HasForeignKey(t => t.TicketOwnerId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    /// <summary>
    /// Configures the one-to-many relationship between Admin and Event (OrganizedEvents).
    /// Sets a cascade delete behavior (if the admin gets deleted so do the events connected to that admin).
    /// </summary>
    private void OnModelCreatingSetAdminsDependencies(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>()
            .HasMany(a => a.OrganizedEvents)
            .WithOne(e => e.Organizer)
            .HasForeignKey(e => e.OrganizerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
    /// <summary>
    /// Configures the one-to-many relationship between Event and Ticket (Tickets).
    /// Sets a cascade delete behavior.
    /// </summary>
    private void OnModelCreatingSetEventsDependencies(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .HasMany(e => e.Tickets)
            .WithOne(t => t.Event)
            .HasForeignKey(t => t.EventId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
    /// <summary>
    /// Overrides the base method to apply all custom entity and relationship configurations.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingSetUsersDiscriminator(modelBuilder);
        OnModelCreatingSetRegularUsersDependencies(modelBuilder);
        OnModelCreatingSetAdminsDependencies(modelBuilder);
        OnModelCreatingSetEventsDependencies(modelBuilder);
    }
}