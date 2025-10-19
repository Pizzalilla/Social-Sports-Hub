using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Social_Sport_Hub.Data;                 // ✅ Data layer (DbContext)
using Social_Sport_Hub.Data.Models;          // ✅ Models (User, SportEvent, etc.)
using Social_Sport_Hub.Services;             // ✅ Service layer
using Social_Sport_Hub.ViewModels;           // ✅ ViewModels (Login, Events, etc.)
using Social_Sport_Hub.Views;                // ✅ Pages (UI)
using System.IO;

namespace Social_Sport_Hub
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            // ✅ Define SQLite database path for EF Core
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "socialsports.db3");

            // ✅ Register EF Core with SQLite provider
            builder.Services.AddDbContext<SportsHubContext>(opt =>
                opt.UseSqlite($"Data Source={dbPath}"));

            // ✅ Register repository + core services
            builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<EventService>();

            // ✅ Register ViewModels
            builder.Services.AddSingleton<EventsViewModel>();        // Shared (keeps event list alive)
            builder.Services.AddTransient<CreateEventViewModel>();   // Fresh instance each time
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<EventDetailViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<CreateEventViewModel>();

            // ✅ Register Pages
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<EventsPage>();
            builder.Services.AddTransient<CreateEventPage>();
            builder.Services.AddTransient<EventDetailPage>();
            //builder.Services.AddTransient<MapPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            // ✅ Make the DI service provider globally available
            App.ServiceProvider = app.Services;

            // ✅ Apply migrations automatically on startup
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<SportsHubContext>();
                db.Database.Migrate();

                // ✅ Seed sample event if none exist (verifies DB connectivity)
                if (!db.SportEvents.Any())
                {
                    db.SportEvents.Add(new SportEvent
                    {
                        Title = "EF Core Test Match",
                        SportType = "Soccer",
                        Address = "Sydney Park",
                        StartTimeUtc = DateTime.UtcNow.AddDays(1),
                        Capacity = 10
                    });
                    db.SaveChanges();
                }

                var count = db.SportEvents.Count();
                System.Diagnostics.Debug.WriteLine($"✅ Database check OK – {count} events found");
            }

            return app;
        }
    }
}
