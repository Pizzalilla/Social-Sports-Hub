using Microsoft.Maui.Storage;

namespace Social_Sport_Hub;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.RegisterPage), typeof(Views.RegisterPage));
        Routing.RegisterRoute("eventdetail", typeof(Views.EventDetailPage)); 
        _ = DecideStartAsync();
    }

    private async Task DecideStartAsync()
    {
        var userId = await SecureStorage.GetAsync("auth_user_id");
        if (string.IsNullOrEmpty(userId))
            await GoToAsync("//login");
        else
            await GoToAsync("//home");
    }
}