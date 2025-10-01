using System.Windows.Input;
using SocialSports.Maui.Data;
using SocialSports.Maui.Services;

namespace SocialSports.Maui.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private readonly AuthService _auth;

    public LoginViewModel()
    {
        // In a real app, use DI. Here we create the DbContext inline for simplicity.
        _auth = new AuthService(new AppDbContext());
        LoginCommand = new Command(async () => await LoginAsync());
    }

    private string _email = "";
    public string Email { get => _email; set => Set(ref _email, value); }

    private string _password = "";
    public string Password { get => _password; set => Set(ref _password, value); }

    public ICommand LoginCommand { get; }

    private async Task LoginAsync()
    {
        var user = await _auth.LoginAsync(Email, Password);
        if (user is not null)
        {
            await Shell.Current.GoToAsync("//EventsPage");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Login failed", "Invalid credentials", "OK");
        }
    }
}
