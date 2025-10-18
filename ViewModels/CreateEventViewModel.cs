using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Social_Sport_Hub.Data.Models;
using Social_Sport_Hub.Models;
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

                // Combine Date + Time for accurate event start
                var startLocal = Date.Date + Time;

                var newEvent = new SportEvent
                {
                    Title = Title,
                    SportType = SportType,
                    Address = Address,
                    StartTimeUtc = startLocal.ToUniversalTime(),
                    Capacity = Capacity
                };

                await _eventService.AddEventAsync(newEvent);

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
