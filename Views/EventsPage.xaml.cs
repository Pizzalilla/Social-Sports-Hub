using Social_Sport_Hub.ViewModels;

namespace Social_Sport_Hub.Views;

public partial class EventsPage : ContentPage
{
    private EventsViewModel ViewModel => BindingContext as EventsViewModel;

    public EventsPage(EventsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is EventsViewModel vm)
        {
            await vm.LoadEventsAsync();
        }
    }
}



