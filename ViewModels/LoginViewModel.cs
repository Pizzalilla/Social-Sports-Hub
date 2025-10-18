using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using Social_Sport_Hub.Services;
using Social_Sport_Hub.Data.Models; // ✅ Ensures access to User type

namespace Social_Sport_Hub.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _auth;

        [ObservableProperty] private string email = string.Empty;
        [ObservableProperty] private string password = string.Empty;
        [ObservableProperty] private bool isBusy;
        [ObservableProperty] private string message = string.Empty;

        public IAsyncRelayCommand LoginCommand { get; }
        public IAsyncRelayCommand NavigateRegisterCommand { get; }

        public LoginViewModel(IAuthService auth)
        {
            _auth = auth;
            LoginCommand = new AsyncRelayCommand(LoginAsync);
            NavigateRegisterCommand = new AsyncRelayCommand(() =>
                Shell.Current.GoToAsync(nameof(Social_Sport_Hub.Views.RegisterPage)));
        }

        private async Task LoginAsync()
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                var (ok, user, error) = await _auth.LoginAsync(Email, Password);

                // Explicitly check for null using 'is null'
                if (!ok || user is null)
                {
                    Message = error ?? "Login failed.";
                    return;
                }

                
                await SecureStorage.SetAsync("auth_user_id", user.Id.ToString());
                await Shell.Current.GoToAsync("//home");
                Message = $"Welcome {user.DisplayName}";
            }
            catch (Exception ex)
            {
                Message = $"Error: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
