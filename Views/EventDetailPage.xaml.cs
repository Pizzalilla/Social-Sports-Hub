using Social_Sport_Hub.ViewModels;

namespace Social_Sport_Hub.Views
{
    [QueryProperty(nameof(EventId), "eventId")]
    public partial class EventDetailPage : ContentPage
    {
        private readonly EventDetailViewModel _vm;
        private string _eventId;

        public string EventId
        {
            get => _eventId;
            set
            {
                _eventId = value;
                if (Guid.TryParse(value, out var id))
                {
                    _ = LoadEventAsync(id);
                }
            }
        }

        public EventDetailPage(EventDetailViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = _vm;
        }

        private async Task LoadEventAsync(Guid eventId)
        {
            await _vm.LoadEventDetailsAsync(eventId);
        }
    }
}