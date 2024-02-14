using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SchoolBus_WPF.Services
{
    public abstract class NotificationServices
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
                    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
