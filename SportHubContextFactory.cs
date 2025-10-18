using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Maui.Storage;
using Social_Sport_Hub.Data;



namespace Social_Sport_Hub
{
    // ✅ Runtime factory for the actual app instance
    public static class SportHubContextFactory
    {
        private static readonly string DbPath = Path.Combine(
            FileSystem.AppDataDirectory, "socialsports.db3");

        public static SportsHubContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<SportsHubContext>()
                .UseSqlite($"Filename={DbPath}")
                .Options;

            return new SportsHubContext(options);
        }

        // Optional for debugging/logging
        public static string GetDatabasePath() => DbPath;
    }
}
