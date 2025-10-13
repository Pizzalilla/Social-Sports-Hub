using Social_Sport_Hub.ViewModels;

namespace Social_Sport_Hub.Views
{
    public partial class ProfilePage : ContentPage
    {
        private readonly ProfileViewModel _vm;

        public ProfilePage(ProfileViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = _vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // TODO: Replace with real current user id from your auth/session
            var currentUserId = Guid.NewGuid();
            await _vm.LoadUserAsync(currentUserId);
        }
    }
}
