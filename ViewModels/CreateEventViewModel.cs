using System.Windows.Input;
using SocialSports.Maui.Data;
using SocialSports.Maui.Models;
using SocialSports.Maui.Services;

namespace SocialSports.Maui.ViewModels;

public class CreateEventViewModel : BaseViewModel
{
    private readonly EventService _service;

    public CreateEventViewModel()
    {
        _service = new EventService(new SportHubDbContext());
        CreateCommand = new Command(async () => await CreateAsync());
        StartTime = DateTime.Now.AddDays(1);
        Capacity = 8;
        Title = "Pickup game";
        Sport = Sport.Soccer;
    }

    public string Title { get; set; }
    public Sport Sport { get; set; }
    public DateTime StartTime { get; set; }
    public int Capacity { get; set; }
    public string LocationName { get; set; } = "Local Park";
    public double Latitude { get; set; } = -33.8688;
    public double Longitude { get; set; } = 151.2093;

    public ICommand CreateCommand { get; }

    private async Task CreateAsync()
    {
        var e = new SportEvent
        {
            Title = Title,
            Sport = Sport,
            StartTime = new DateTimeOffset(StartTime),
            Capacity = Capacity,
            PlayersJoined = 1,
            HostId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
            LocationName = LocationName,
            Latitude = Latitude,
            Longitude = Longitude
        };
        await _service.CreateAsync(e);
        await Application.Current.MainPage.DisplayAlert("Created", "Your event is live!", "OK");
        await Shell.Current.GoToAsync("//EventsPage");
    }
}
