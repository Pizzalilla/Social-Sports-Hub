using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Social_Sport_Hub.Data; 
using Social_Sport_Hub.Data.Models;
using Social_Sport_Hub.Services;  
using Social_Sport_Hub.ViewModels;     
using Social_Sport_Hub.Views;                
using System.IO;

namespace Social_Sport_Hub
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "socialsports.db3");

            builder.Services.AddDbContext<SportsHubContext>(opt =>
                opt.UseSqlite($"Data Source={dbPath}"));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<EventService>();

            // ✅ Register ViewModels
            builder.Services.AddSingleton<EventsViewModel>();       
            builder.Services.AddTransient<CreateEventViewModel>();   
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
            builder.Services.AddTransient<MapPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            App.ServiceProvider = app.Services;

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<SportsHubContext>();
                db.Database.Migrate();

                // sample event if none exist (verifies DB connectivity)
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
