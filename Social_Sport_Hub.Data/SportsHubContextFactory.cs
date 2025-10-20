using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Social_Sport_Hub.Data
{
    /// <summary>
    /// Factory used exclusively by EF Core tools at design-time (for migrations).
    /// </summary>
    public sealed class SportsHubContextFactory : IDesignTimeDbContextFactory<SportsHubContext>
    {
        public SportsHubContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SportsHubContext>();

            // Place design-time database alongside build output so EF migrations always find it
            var dataDir = Path.Combine(AppContext.BaseDirectory, "data");
            Directory.CreateDirectory(dataDir);

            var dbPath = Path.Combine(dataDir, "socialsports.design.db3");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            System.Diagnostics.Debug.WriteLine($"[EF DESIGN-TIME] Using database path: {dbPath}");

            return new SportsHubContext(optionsBuilder.Options);
        }
    }
}
