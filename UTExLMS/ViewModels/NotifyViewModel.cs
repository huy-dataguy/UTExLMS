using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UTExLMS.Models;
using UTExLMS.Service;
namespace UTExLMS.ViewModels
{
    public class NotifyViewModel : ViewModelBase
    {
        private readonly NotifyService _notifyService;
        private ObservableCollection<Notify> _listDeadline;

        public event PropertyChangedEventHandler PropertyChanged;
        private Notify _notify;

        public NotifyViewModel(int idstudent)
        {
            _notifyService = new NotifyService();

            _listDeadline = new ObservableCollection<Notify>();
            LoadNotifications(idstudent);
        }

        public ObservableCollection<Notify> ListDeadline
        {
            get => _listDeadline;
            set
            {
                if (_listDeadline != null)
                {
                    _listDeadline = value;
                    OnPropertyChanged();
                }
            }
        }

        private void LoadNotifications(int studentId)
        {
            ListDeadline = _notifyService.GetUpcomingDeadlinesForStudent(studentId);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
