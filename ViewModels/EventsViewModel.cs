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
    }
}