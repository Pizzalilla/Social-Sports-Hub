using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Social_Sport_Hub.Data.Models;

namespace Social_Sport_Hub.Data
{
    /// Central Entity Framework Core database context for the Social Sport Hub app.
    /// Manages Users, Events, Attendance, and Honor history tables.
    public sealed class SportsHubContext : DbContext
    {
        public SportsHubContext(DbContextOptions<SportsHubContext> options) : base(options)
        {
            //Log database path for debugging
            try
            {
                var dbPath = Database.GetDbConnection().DataSource;
                System.Diagnostics.Debug.WriteLine($"[DB PATH] Using database: {dbPath}");
            }
            catch
            {
            }
        }

        //DbSets
        public DbSet<User> Users => Set<User>();
        public DbSet<HostUser> Hosts => Set<HostUser>();
        public DbSet<PlayerUser> Players => Set<PlayerUser>();
        public DbSet<SportEvent> SportEvents => Set<SportEvent>();
        public DbSet<AttendanceRecord> AttendanceRecords => Set<AttendanceRecord>();
        public DbSet<HonorHistoryRecord> HonorHistory => Set<HonorHistoryRecord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Inheritance for User → HostUser/PlayerUser with discriminator
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<PlayerUser>("Player")
                .HasValue<HostUser>("Host");

            // Unique email constraint for all users
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Define relationship between SportEvent and AttendanceRecord
            modelBuilder.Entity<AttendanceRecord>()
                .HasOne(a => a.SportEvent)
                .WithMany(e => e.AttendanceRecords)
                .HasForeignKey(a => a.SportEventId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Local fallback database path (cross-platform safe)
                var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                if (string.IsNullOrWhiteSpace(folder))
                {
                    folder = Path.Combine(AppContext.BaseDirectory, "data");
                }

                Directory.CreateDirectory(folder);
                var dbPath = Path.Combine(folder, "socialsports.db3");
                optionsBuilder.UseSqlite($"Data Source={dbPath}");

                System.Diagnostics.Debug.WriteLine($"📁 Fallback DB Path: {dbPath}");
            }
        }
    }
}

