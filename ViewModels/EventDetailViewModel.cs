using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Social_Sport_Hub.Data;
using Social_Sport_Hub.Data.Models;
using System.Collections.ObjectModel;

namespace Social_Sport_Hub.ViewModels
{
    public partial class EventDetailViewModel : ObservableObject
    {
        private readonly SportsHubContext _context;

        [ObservableProperty] private SportEvent _event;
        [ObservableProperty] private ObservableCollection<User> attendees = new();
        [ObservableProperty] private bool isBusy;
        [ObservableProperty] private string hostName = string.Empty;
        [ObservableProperty] private string hostPhone = string.Empty;
        [ObservableProperty] private string hostEmail = string.Empty;
        [ObservableProperty] private string capacityDisplay = string.Empty;

        public EventDetailViewModel(SportsHubContext context)
        {
            _context = context;
        }

        public async Task LoadEventDetailsAsync(Guid eventId)
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                // Load event
                Event = await _context.SportEvents.FindAsync(eventId);

                if (Event != null)
                {
                    // Load host details
                    var host = await _context.Users.FindAsync(Event.HostUserId);
                    if (host != null)
                    {
                        HostName = host.DisplayName;
                        HostEmail = host.Email;
                        HostPhone = await SecureStorage.GetAsync($"phone_{host.Id}") ?? "Not provided";
                    }
                }

                // Load attendees
                var userIds = await _context.AttendanceRecords
                    .Where(a => a.SportEventId == eventId)
                    .Select(a => a.UserId)
                    .ToListAsync();

                var users = await _context.Users
                    .Where(u => userIds.Contains(u.Id))
                    .ToListAsync();

                Attendees.Clear();
                foreach (var user in users)
                    Attendees.Add(user);

                // Update capacity display
                if (Event != null)
                {
                    CapacityDisplay = $"{Attendees.Count}/{Event.Capacity}";
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task JoinEventAsync()
        {
            if (IsBusy || Event == null) return;

            try
            {
                IsBusy = true;

                var userIdStr = await SecureStorage.GetAsync("auth_user_id");
                if (string.IsNullOrEmpty(userIdStr))
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Please log in first", "OK");
                    return;
                }

                var userId = Guid.Parse(userIdStr);

                // Check if already joined
                var existingAttendance = await _context.AttendanceRecords
                    .FirstOrDefaultAsync(a => a.SportEventId == Event.Id && a.UserId == userId);

                if (existingAttendance != null)
                {
                    await App.Current.MainPage.DisplayAlert("Already Joined",
                        "You're already registered for this event", "OK");
                    return;
                }

                // Check capacity
                if (Attendees.Count >= Event.Capacity)
                {
                    await App.Current.MainPage.DisplayAlert("Event Full",
                        "This event has reached maximum capacity", "OK");
                    return;
                }

                var attendance = new AttendanceRecord
                {
                    SportEventId = Event.Id,
                    UserId = userId,
                    Status = AttendanceStatus.Confirmed,
                    MarkedAtUtc = DateTime.UtcNow
                };

                _context.AttendanceRecords.Add(attendance);
                await _context.SaveChangesAsync();

                await App.Current.MainPage.DisplayAlert("Success",
                    $"You've joined {Event.Title}!", "OK");

                await LoadEventDetailsAsync(Event.Id);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error",
                    $"Failed to join: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}