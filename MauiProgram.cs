using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Social_Sport_Hub.Data;          
using Social_Sport_Hub.Services;     
using Social_Sport_Hub.ViewModels;    
using Social_Sport_Hub.Views;         

namespace Social_Sport_Hub;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();

        // SQLite path for EF
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "socialsports.db3");

        // EF Core Sqlite
        builder.Services.AddDbContext<SportsHubContext>(opt =>
            opt.UseSqlite($"Data Source={dbPath}"));

        // Repos & Services (adjust to your actual types)
        builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        builder.Services.AddScoped<IAuthService, AuthService>();

        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();

        // Pages (resolved from DI)
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<ProfilePage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

        // Make the ServiceProvider available to XAML-created pages
        App.ServiceProvider = app.Services;

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<SportsHubContext>();
            db.Database.Migrate();
        }

        return app;
    }
}
