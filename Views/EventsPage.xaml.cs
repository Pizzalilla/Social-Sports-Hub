namespace SocialSports.Maui.Views;

public partial class EventsPage : ContentPage
{
    public EventsPage()
    {
        InitializeComponent();
        var vm = new ViewModels.EventsViewModel();
        BindingContext = vm;
        // Trigger initial load
        Task.Run(async () => await MainThread.InvokeOnMainThreadAsync(async () => await vm.LoadCommand.Execute(null)));
    }
}
