using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Social_Sport_Hub.Messages;
using Social_Sport_Hub.Data.Models;
using Social_Sport_Hub.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Social_Sport_Hub.ViewModels
{
    public partial class EventsViewModel : ObservableObject
    {
        private readonly EventService _eventService;

        [ObservableProperty]
        private ObservableCollection<SportEvent> events = new();

        [ObservableProperty]
        private bool isBusy;

        public EventsViewModel(EventService eventService)
        {
            _eventService = eventService;

            // Automatically refresh when a new event is created
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

                // Ensure thread-safe UI updates
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Events.Clear();
                    foreach (var item in list)
                        Events.Add(item);
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

        // ensures first-time page load populates events
        public async Task RefreshIfEmptyAsync()
        {
            if (Events.Count == 0 && !IsBusy)
            {
                await LoadEventsAsync();
            }
        }
    }
}
