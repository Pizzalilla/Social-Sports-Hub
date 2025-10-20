using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Social_Sport_Hub.Data;
using Social_Sport_Hub.Data.Models;
using System.Collections.ObjectModel;

namespace Social_Sport_Hub.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        private readonly SportsHubContext _context;
        private Guid _currentUserId;

        [ObservableProperty] private string displayName = string.Empty;
        [ObservableProperty] private string email = string.Empty;
        [ObservableProperty] private string phoneNumber = string.Empty;
        [ObservableProperty] private string profilePhotoPath = "dotnet_bot.png"; // Default image
        [ObservableProperty] private string selectedSport = string.Empty;
        [ObservableProperty] private bool isBusy;

        public ObservableCollection<string> PreferredSports { get; } = new();

        public List<string> AvailableSports { get; } = new()
        {
            "Soccer", "Basketball", "Cricket", "Tennis",
            "Volleyball", "Rugby", "Running", "Other"
        };

        public ProfileViewModel(SportsHubContext context)
        {
            _context = context;
        }

        public async Task LoadUserProfileAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                var userIdStr = await SecureStorage.GetAsync("auth_user_id");
                if (string.IsNullOrEmpty(userIdStr))
                {
                    await Shell.Current.GoToAsync("//login");
                    return;
                }

                _currentUserId = Guid.Parse(userIdStr);

                var user = await _context.Users.FindAsync(_currentUserId);
                if (user != null)
                {
                    DisplayName = user.DisplayName;
                    Email = user.Email;

                    // Load additional profile data from SecureStorage
                    PhoneNumber = await SecureStorage.GetAsync($"phone_{_currentUserId}") ?? string.Empty;
                    ProfilePhotoPath = await SecureStorage.GetAsync($"photo_{_currentUserId}") ?? "dotnet_bot.png";

                    var sportsData = await SecureStorage.GetAsync($"sports_{_currentUserId}");
                    if (!string.IsNullOrEmpty(sportsData))
                    {
                        PreferredSports.Clear();
                        foreach (var sport in sportsData.Split(','))
                        {
                            PreferredSports.Add(sport);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Failed to load profile: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task AddSportAsync()
        {
            if (string.IsNullOrWhiteSpace(SelectedSport) || PreferredSports.Contains(SelectedSport))
                return;

            PreferredSports.Add(SelectedSport);
            await SavePreferredSportsAsync();
            SelectedSport = string.Empty;
        }

        [RelayCommand]
        private async Task RemoveSportAsync(string sport)
        {
            PreferredSports.Remove(sport);
            await SavePreferredSportsAsync();
        }

        [RelayCommand]
        private async Task PickPhotoAsync()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Select Profile Photo"
                });

                if (result != null)
                {
                    // Copy to app data directory
                    var newFile = Path.Combine(FileSystem.AppDataDirectory, $"profile_{_currentUserId}.jpg");
                    using (var stream = await result.OpenReadAsync())
                    using (var newStream = File.OpenWrite(newFile))
                    {
                        await stream.CopyToAsync(newStream);
                    }

                    ProfilePhotoPath = newFile;
                    await SecureStorage.SetAsync($"photo_{_currentUserId}", newFile);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Failed to pick photo: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private async Task SaveProfileAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                var user = await _context.Users.FindAsync(_currentUserId);
                if (user != null)
                {
                    user.DisplayName = DisplayName;
                    await _context.SaveChangesAsync();
                }

                // Save contact details to SecureStorage
                await SecureStorage.SetAsync($"phone_{_currentUserId}", PhoneNumber);

                await App.Current.MainPage.DisplayAlert("Success", "Profile updated!", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Failed to save: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task LogoutAsync()
        {
            SecureStorage.Remove("auth_user_id");
            await Shell.Current.GoToAsync("//login");
        }

        private async Task SavePreferredSportsAsync()
        {
            var sportsData = string.Join(",", PreferredSports);
            await SecureStorage.SetAsync($"sports_{_currentUserId}", sportsData);
        }
    }
}