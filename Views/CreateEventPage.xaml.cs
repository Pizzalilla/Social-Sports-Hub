namespace SocialSports.Maui.Views;

public partial class CreateEventPage : ContentPage
{
    public CreateEventPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.CreateEventViewModel();
    }
}
