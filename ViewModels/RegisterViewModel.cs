using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using Social_Sport_Hub.Services;

namespace Social_Sport_Hub.ViewModels;

public partial class RegisterViewModel : ObservableObject
{
    private readonly IAuthService _auth;

    [ObservableProperty] private string email = string.Empty;
    [ObservableProperty] private string password = string.Empty;
    [ObservableProperty] private string displayName = string.Empty;
    [ObservableProperty] private bool isBusy;
    [ObservableProperty] private string message = string.Empty;

    public IAsyncRelayCommand RegisterCommand { get; }

    public RegisterViewModel(IAuthService auth)
    {
        _auth = auth;
        RegisterCommand = new AsyncRelayCommand(RegisterAsync);
    }

    private async Task RegisterAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        try
        {
            var (ok, err) = await _auth.RegisterAsync(Email, Password, DisplayName);
            if (!ok)
            {
                Message = err ?? "Registration failed.";
                return;
            }

            // Auto-login after sign up
            var (ok2, user, err2) = await _auth.LoginAsync(Email, Password);
            if (!ok2 || user is null)
            {
                Message = err2 ?? "Account created. Please log in.";
                await Shell.Current.GoToAsync("//login");
                return;
            }

            await SecureStorage.SetAsync("auth_user_id", user.Id.ToString());
            await Shell.Current.GoToAsync("//home");
            Message = "Registration successful";
        }
        finally { IsBusy = false; }
    }
}
