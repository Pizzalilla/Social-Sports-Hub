using Social_Sport_Hub.ViewModels;

namespace Social_Sport_Hub.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = App.ServiceProvider.GetRequiredService<LoginViewModel>();
    }
}
