using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Social_Sport_Hub.Data;
using Social_Sport_Hub.Data.Models;
using Social_Sport_Hub.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Social_Sport_Hub.ViewModels
{
    public partial class CreateEventViewModel : ObservableObject
    {
        private readonly EventService _eventService;
        private readonly SportsHubContext _context;

        // 🔹 Properties bound to UI
        [ObservableProperty] private string title = string.Empty;
        [ObservableProperty] private string sportType = string.Empty;
        [ObservableProperty] private string address = string.Empty;

        // ✅ Split date and time for proper Picker binding
        [ObservableProperty] private DateTime date = DateTime.Today.AddDays(1);
        [ObservableProperty] private TimeSpan time = new(12, 0, 0); // default 12 PM

        [ObservableProperty] private int capacity = 10;
        [ObservableProperty] private bool isBusy;

        // 🔹 Dropdown options for the Picker
        public List<string> SportOptions { get; } = new()
        {
            "Soccer",
            "Basketball",
            "Cricket",
            "Tennis",
            "Volleyball",
            "Rugby",
            "Running",
            "Other"
        };

        // 🔔 Event raised after successful creation
        public event EventHandler? EventCreated;

        public CreateEventViewModel(EventService eventService)
        {
            _eventService = eventService;
        }

        [RelayCommand]
        public async Task CreateEventAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                // Get current user ID
                var userIdStr = await SecureStorage.GetAsync("auth_user_id");
                if (string.IsNullOrEmpty(userIdStr))
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Please log in first", "OK");
                    return;
                }

                var userId = Guid.Parse(userIdStr);

                // Combine Date + Time for accurate event start
                var startLocal = Date.Date + Time;

                var newEvent = new SportEvent
                {
                    Title = Title,
                    SportType = SportType,
                    Address = Address,
                    StartTimeUtc = startLocal.ToUniversalTime(),
                    Capacity = Capacity,
                    HostUserId = userId // ✅ Set the host
                };

                await _eventService.AddEventAsync(newEvent);

                // ✅ AUTO-ADD CREATOR TO ATTENDANCE
                var context = App.ServiceProvider.GetRequiredService<SportsHubContext>();
                context.AttendanceRecords.Add(new AttendanceRecord
                {
                    SportEventId = newEvent.Id,
                    UserId = userId,
                    Status = AttendanceStatus.Confirmed,
                    MarkedAtUtc = DateTime.UtcNow
                });
                await context.SaveChangesAsync();

                // Notify that the event was successfully created
                EventCreated?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Failed to create event: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
