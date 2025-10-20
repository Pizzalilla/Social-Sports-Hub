using Social_Sport_Hub.ViewModels;

namespace Social_Sport_Hub.Views;

public partial class EventsPage : ContentPage
{
    private bool _isFilterVisible = false;
    private EventsViewModel _viewModel;

    public EventsPage(EventsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        System.Diagnostics.Debug.WriteLine("🔄 EventsPage appearing - forcing refresh");

        // ✅ FIX: Always force refresh when page appears
        if (_viewModel != null)
        {
            // Restore filter picker state
            if (!string.IsNullOrEmpty(_viewModel.CurrentFilter))
            {
                SportFilterPicker.SelectedItem = _viewModel.CurrentFilter;
            }

            // Force reload
            await _viewModel.LoadEventsAsync();
        }
    }

    private async void OnToggleFilterClicked(object sender, EventArgs e)
    {
        try
        {
            _isFilterVisible = !_isFilterVisible;

            if (_isFilterVisible)
            {
                FilterFrame.IsVisible = true;
                await ChevronIcon.RotateTo(180, 250, Easing.CubicOut);

                FilterFrame.Opacity = 0;
                FilterFrame.TranslationY = -20;
                await Task.WhenAll(
                    FilterFrame.FadeTo(1, 250),
                    FilterFrame.TranslateTo(0, 0, 250, Easing.CubicOut)
                );
            }
            else
            {
                await ChevronIcon.RotateTo(0, 250, Easing.CubicIn);

                await Task.WhenAll(
                    FilterFrame.FadeTo(0, 200),
                    FilterFrame.TranslateTo(0, -20, 200, Easing.CubicIn)
                );
                FilterFrame.IsVisible = false;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error toggling filter: {ex.Message}");
        }
    }

    private async void OnApplyFilterClicked(object sender, EventArgs e)
    {
        try
        {
            var selectedSport = SportFilterPicker.SelectedItem as string;
            System.Diagnostics.Debug.WriteLine($"🎯 Apply clicked with sport: {selectedSport}");

            if (_viewModel != null)
            {
                await _viewModel.FilterEventsBySportCommand.ExecuteAsync(selectedSport);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"❌ Filter error: {ex.Message}");
            await DisplayAlert("Error", $"Filter failed: {ex.Message}", "OK");
        }
    }
}