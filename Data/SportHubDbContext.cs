using Microsoft.EntityFrameworkCore;
using Social_Sport_Hub.Models;
using System.Reflection.Emit;

namespace Social_Sport_Hub.Data
{
    // SQLite-backed EF Core context for the Social Sports Hub app.
    public sealed class SportsHubContext : DbContext
    {
        public SportsHubContext(DbContextOptions<SportsHubContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<HostUser> Hosts => Set<HostUser>();
        public DbSet<PlayerUser> Players => Set<PlayerUser>();
        public DbSet<SportEvent> SportEvents => Set<SportEvent>();
        public DbSet<AttendanceRecord> AttendanceRecords => Set<AttendanceRecord>();
        public DbSet<HonorHistoryRecord> HonorHistory => Set<HonorHistoryRecord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<PlayerUser>("Player")
                .HasValue<HostUser>("Host");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<SportEvent>()
                .OwnsOne(e => e.Roster, nav =>
                {
                    nav.Ignore(r => r.ConfirmedPlayers);
                    nav.Ignore(r => r.WaitlistedPlayers);
                });
        }
    }
}
