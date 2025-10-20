using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using Social_Sport_Hub.Data;
using Social_Sport_Hub.Data.Models;
using Social_Sport_Hub.Messages; 
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
        [ObservableProperty] private bool isHost;
        [ObservableProperty] private bool isNotHost = true;

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
                    // Check if current user is the host
                    var currentUserIdStr = await SecureStorage.GetAsync("auth_user_id");
                    if (!string.IsNullOrEmpty(currentUserIdStr) && Guid.TryParse(currentUserIdStr, out var currentUserId))
                    {
                        IsHost = Event.HostUserId == currentUserId;
                        IsNotHost = !IsHost;
                    }
                    else
                    {
                        IsHost = false;
                        IsNotHost = true;
                    }

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

                // ✅ FIX: Reload event details immediately
                await LoadEventDetailsAsync(Event.Id);

                await App.Current.MainPage.DisplayAlert("Success",
                    $"You've joined {Event.Title}!", "OK");

                // Send message to refresh events list
                WeakReferenceMessenger.Default.Send(new EventsUpdatedMessage());
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

        [RelayCommand]
        private async Task ViewUserProfileAsync(User user)
        {
            if (user == null) return;

            var userType = user is HostUser ? "Host" : "Player";
            var memberSince = user.CreatedAtUtc.ToString("MMMM dd, yyyy");

            await App.Current.MainPage.DisplayAlert(
                $"{user.DisplayName}'s Profile",
                $"📧 Email: {user.Email}\n" +
                $"📅 Member since: {memberSince}\n" +
                $"👤 User type: {userType}\n",
                "Close"
            );
        }

        [RelayCommand]
        private async Task RemoveAttendeeAsync(User user)
        {
            if (IsBusy || Event == null || user == null) return;

            try
            {
                var currentUserIdStr = await SecureStorage.GetAsync("auth_user_id");
                if (string.IsNullOrEmpty(currentUserIdStr))
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Please log in first", "OK");
                    return;
                }

                var currentUserId = Guid.Parse(currentUserIdStr);

                // Only host can remove attendees
                if (Event.HostUserId != currentUserId)
                {
                    await App.Current.MainPage.DisplayAlert("Error",
                        "Only the event host can remove attendees", "OK");
                    return;
                }

                // Can't remove yourself
                if (user.Id == currentUserId)
                {
                    await App.Current.MainPage.DisplayAlert("Error",
                        "You cannot remove yourself. Cancel the event instead.", "OK");
                    return;
                }

                var confirm = await App.Current.MainPage.DisplayAlert(
                    "Remove Attendee",
                    $"Remove {user.DisplayName} from this event?",
                    "Yes", "No");

                if (!confirm) return;

                IsBusy = true;

                var attendance = await _context.AttendanceRecords
                    .FirstOrDefaultAsync(a => a.SportEventId == Event.Id && a.UserId == user.Id);

                if (attendance != null)
                {
                    _context.AttendanceRecords.Remove(attendance);
                    await _context.SaveChangesAsync();

                    // ✅ FIX: Reload event details immediately
                    await LoadEventDetailsAsync(Event.Id);

                    await App.Current.MainPage.DisplayAlert("Success",
                        $"{user.DisplayName} has been removed from the event", "OK");

                    // Send message to refresh events list
                    WeakReferenceMessenger.Default.Send(new EventsUpdatedMessage());
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error",
                    $"Failed to remove attendee: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }


        [RelayCommand]
        private async Task DeleteEventAsync()
        {
            if (IsBusy || Event == null) return;

            try
            {
                var currentUserIdStr = await SecureStorage.GetAsync("auth_user_id");
                if (string.IsNullOrEmpty(currentUserIdStr))
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Please log in first", "OK");
                    return;
                }

                var currentUserId = Guid.Parse(currentUserIdStr);

                // Only host can delete event
                if (Event.HostUserId != currentUserId)
                {
                    await App.Current.MainPage.DisplayAlert("Error",
                        "Only the event host can delete this event", "OK");
                    return;
                }

                var confirm = await App.Current.MainPage.DisplayAlert(
                    "Delete Event",
                    $"Are you sure you want to delete '{Event.Title}'? This cannot be undone.",
                    "Delete", "Cancel");

                if (!confirm) return;

                IsBusy = true;

                // Delete all attendance records first
                var attendances = await _context.AttendanceRecords
                    .Where(a => a.SportEventId == Event.Id)
                    .ToListAsync();

                _context.AttendanceRecords.RemoveRange(attendances);

                // Delete the event
                _context.SportEvents.Remove(Event);
                await _context.SaveChangesAsync();

                await App.Current.MainPage.DisplayAlert("Success",
                    "Event has been deleted", "OK");

                // ✅ FIX: Send message to refresh events list
                WeakReferenceMessenger.Default.Send(new EventsUpdatedMessage());

                // Navigate back
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error",
                    $"Failed to delete event: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}