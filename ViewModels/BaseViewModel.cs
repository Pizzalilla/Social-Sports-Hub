using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Social_Sport_Hub.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set { _isBusy = value; OnPropertyChanged(); }
        }

        private string? _message;
        public string? Message
        {
            get => _message;
            set { _message = value; OnPropertyChanged(); }
        }
    }
}
