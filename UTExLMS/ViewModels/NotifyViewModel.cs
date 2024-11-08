using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UTExLMS.Commands;
using UTExLMS.Service;
using UTExLMS.Models;
using System.Runtime.CompilerServices;
namespace UTExLMS.ViewModels
{
    public class NotifyViewModel : ViewModelBase
    {
        private readonly NotifyService _notifyService;
        private ObservableCollection<Notify> _listDeadline;
        public event PropertyChangedEventHandler PropertyChanged;


        public NotifyViewModel()
        {
            _notifyService = new NotifyService();
            _listDeadline = new ObservableCollection<Notify>();
            LoadNotifications(102);
        }

        public ObservableCollection<Notify> ListDeadline
        {
            get => _listDeadline;
            set
            {
                if(_listDeadline!= null)
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