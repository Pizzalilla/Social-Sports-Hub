using Microsoft.EntityFrameworkCore;
using SocialSports.Maui.Models;

namespace SocialSports.Maui.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<SportEvent> Events => Set<SportEvent>();

    public AppDbContext() {}
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=socialsports.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed minimal demo data
        var demoUser = new User
        {
            Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
            Email = "host@example.com",
            DisplayName = "Demo Host",
            PasswordHash = "demo"
        };

        var e1 = new SportEvent
        {
            Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
            Title = "Pickup Soccer at the Park",
            Sport = Sport.Soccer,
            StartTime = DateTimeOffset.UtcNow.AddDays(1).AddHours(2),
            Capacity = 10,
            PlayersJoined = 3,
            HostId = demoUser.Id,
            Latitude = -33.8688,
            Longitude = 151.2093,
            LocationName = "Sydney Park"
        };

        modelBuilder.Entity<User>().HasData(demoUser);
        modelBuilder.Entity<SportEvent>().HasData(e1);
    }
}
