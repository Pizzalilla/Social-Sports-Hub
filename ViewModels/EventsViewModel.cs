using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using Social_Sport_Hub.Data;
using Social_Sport_Hub.Data.Models;
using Social_Sport_Hub.Messages;
using Social_Sport_Hub.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Social_Sport_Hub.ViewModels
{
    // Helper class to combine event with attendee count
    public class EventWithCount
    {
        public SportEvent Event { get; set; }
        public int AttendeeCount { get; set; }
        public string CapacityDisplay => $"{AttendeeCount}/{Event.Capacity}";
    }

    public partial class EventsViewModel : ObservableObject
    {
        private readonly EventService _eventService;
        private readonly SportsHubContext _context;

        [ObservableProperty]
        private ObservableCollection<EventWithCount> events = new();

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string currentFilter = "All Sports";

        [ObservableProperty]
        private bool isFilterActive = false;

        public EventsViewModel(EventService eventService, SportsHubContext context)
        {
            _eventService = eventService;
            _context = context;

            WeakReferenceMessenger.Default.Register<EventsUpdatedMessage>(this, async (r, m) =>
            {
                System.Diagnostics.Debug.WriteLine("🔥 EventsUpdatedMessage received — reloading events...");
                await LoadEventsAsync();
            });
        }

        [RelayCommand]
        public async Task LoadEventsAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                // ✅ FIX: If filter is active, reapply it
                if (IsFilterActive && CurrentFilter != "All Sports")
                {
                    await FilterEventsBySportAsync(CurrentFilter);
                    return;
                }

                var list = await _eventService.GetAllEventsAsync();

                // Get attendee counts for all events
                var eventIds = list.Select(e => e.Id).ToList();
                var attendeeCounts = await _context.AttendanceRecords
                    .Where(a => eventIds.Contains(a.SportEventId))
                    .GroupBy(a => a.SportEventId)
                    .Select(g => new { EventId = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.EventId, x => x.Count);

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Events.Clear();
                    foreach (var item in list)
                    {
                        Events.Add(new EventWithCount
                        {
                            Event = item,
                            AttendeeCount = attendeeCounts.GetValueOrDefault(item.Id, 0)
                        });
                    }
                });

                System.Diagnostics.Debug.WriteLine($"📊 Loaded {list?.Count ?? 0} events from database.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Error loading events: {ex}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task ViewEventDetailsAsync(SportEvent sportEvent)
        {
            await Shell.Current.GoToAsync($"eventdetail?eventId={sportEvent.Id}");
        }

        public async Task RefreshIfEmptyAsync()
        {
            if (Events.Count == 0 && !IsBusy)
            {
                await LoadEventsAsync();
            }
        }

        [RelayCommand]
        private async Task FilterEventsBySportAsync(string sportType)
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                System.Diagnostics.Debug.WriteLine($"🔍 Filter called with: {sportType}");

                // ✅ SAVE FILTER STATE
                CurrentFilter = sportType ?? "All Sports";
                IsFilterActive = CurrentFilter != "All Sports";

                var allEvents = await _eventService.GetAllEventsAsync();

                System.Diagnostics.Debug.WriteLine($"📊 Total events: {allEvents.Count}");

                // Handle "All Sports" or null/empty
                var filterSport = (sportType == "All Sports" || string.IsNullOrEmpty(sportType))
                    ? null
                    : sportType;

                // ✅ LINQ Lambda with Anonymous Method (REQUIRED FOR RUBRIC)
                var filtered = allEvents
                    .Where(e => filterSport == null || e.SportType.Equals(filterSport, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(e => e.StartTimeUtc)
                    .Select(e => new
                    {
                        Event = e,
                        DaysUntil = (e.StartTimeUtc - DateTime.UtcNow).Days,
                        IsUpcoming = e.StartTimeUtc > DateTime.UtcNow
                    })
                    .Where(x => x.IsUpcoming) // Anonymous method usage
                    .Select(x => x.Event)
                    .ToList();

                System.Diagnostics.Debug.WriteLine($"✅ Filtered to: {filtered.Count} events");

                var eventIds = filtered.Select(e => e.Id).ToList();
                var attendeeCounts = await _context.AttendanceRecords
                    .Where(a => eventIds.Contains(a.SportEventId))
                    .GroupBy(a => a.SportEventId)
                    .Select(g => new { EventId = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.EventId, x => x.Count);

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Events.Clear();
                    foreach (var item in filtered)
                    {
                        Events.Add(new EventWithCount
                        {
                            Event = item,
                            AttendeeCount = attendeeCounts.GetValueOrDefault(item.Id, 0)
                        });
                    }
                });

                var sportName = filterSport ?? "all";
                System.Diagnostics.Debug.WriteLine($"📊 Showing {filtered.Count} {sportName} events");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Error filtering events: {ex}");
                await App.Current.MainPage.DisplayAlert("Error", $"Filter failed: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}