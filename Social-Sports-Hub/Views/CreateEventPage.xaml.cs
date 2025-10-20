using CommunityToolkit.Mvvm.Messaging;
using Social_Sport_Hub.ViewModels;
using Social_Sport_Hub.Messages;

namespace Social_Sport_Hub.Views
{
    public partial class CreateEventPage : ContentPage
    {
        private readonly CreateEventViewModel _vm;

        public CreateEventPage(CreateEventViewModel vm)
        {
            InitializeComponent();
            BindingContext = _vm = vm;

            // Subscribe once to the event (prevent multiple triggers)
            _vm.EventCreated += OnEventCreated;
        }

        private async void OnEventCreated(object? sender, EventArgs e)
        {
            try
            {
                // Visual confirmation
                await DisplayAlert("Success", "Event created successfully!", "OK");

                // Notify global listeners (like EventsViewModel) to refresh
                WeakReferenceMessenger.Default.Send(new EventsUpdatedMessage());

                // Navigate back using Shell — this matches your current navigation stack
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Navigation or refresh failed: {ex.Message}", "OK");
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Prevent duplicate handler subscription on next navigation
            _vm.EventCreated -= OnEventCreated;
        }
    }
}
