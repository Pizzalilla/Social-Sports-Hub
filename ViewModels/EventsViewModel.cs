using System.Collections.ObjectModel;
using System.Windows.Input;
using SocialSports.Maui.Data;
using SocialSports.Maui.Models;
using SocialSports.Maui.Services;

namespace SocialSports.Maui.ViewModels;

public class EventsViewModel : BaseViewModel
{
    private readonly EventService _service;
    public ObservableCollection<SportEvent> Events { get; } = new();

    public EventsViewModel()
    {
        _service = new EventService(new AppDbContext());
        LoadCommand = new Command(async () => await LoadAsync());
        JoinCommand = new Command<Guid>(async id => await JoinAsync(id));
    }

    public ICommand LoadCommand { get; }
    public ICommand JoinCommand { get; }

    private async Task LoadAsync()
    {
        Events.Clear();
        foreach (var e in await _service.GetUpcomingAsync())
            Events.Add(e);
    }

    private async Task JoinAsync(Guid id)
    {
        var ok = await _service.JoinAsync(id);
        await Application.Current.MainPage.DisplayAlert(ok ? "Joined!" : "Full", ok ? "See you there!" : "No more spots.", "OK");
        if (ok) await LoadAsync();
    }
}
