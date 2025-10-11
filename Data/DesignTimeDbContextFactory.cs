using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SocialSports.Maui.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SportHubDbContext>
{
    public SportHubDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<SportHubDbContext>()
            .UseSqlite("Data Source=socialsports.db");
        return new AppDbContext(builder.Options);
    }
}
