using Social_Sport_Hub.ViewModels;

namespace Social_Sport_Hub.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        BindingContext = App.ServiceProvider.GetRequiredService<RegisterViewModel>();
    }
}
