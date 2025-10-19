using Social_Sport_Hub.ViewModels;

namespace Social_Sport_Hub.Views;

public partial class EventsPage : ContentPage
{
    private bool _isFilterVisible = false;

    public EventsPage(EventsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is EventsViewModel vm)
        {
            await vm.LoadEventsAsync();
        }
    }

    private async void OnToggleFilterClicked(object sender, EventArgs e)
    {
        _isFilterVisible = !_isFilterVisible;

        if (_isFilterVisible)
        {
            // Show filter
            FilterFrame.IsVisible = true;

            // Rotate chevron up
            await ChevronIcon.RotateTo(180, 250, Easing.CubicOut);

            // Animate filter in
            FilterFrame.Opacity = 0;
            FilterFrame.TranslationY = -20;
            await Task.WhenAll(
                FilterFrame.FadeTo(1, 250),
                FilterFrame.TranslateTo(0, 0, 250, Easing.CubicOut)
            );
        }
        else
        {
            // Hide filter

            // Rotate chevron down
            await ChevronIcon.RotateTo(0, 250, Easing.CubicIn);

            // Animate filter out
            await Task.WhenAll(
                FilterFrame.FadeTo(0, 200),
                FilterFrame.TranslateTo(0, -20, 200, Easing.CubicIn)
            );
            FilterFrame.IsVisible = false;
        }
    }
}