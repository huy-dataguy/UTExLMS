using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Service;
using UTExLMS.Commands;
using HandyControl.Data;
using HandyControl.Controls;
using UTExLMS.Views;


namespace UTExLMS.ViewModels
{
    public class ControlPandelViewModel : ViewModelBase
    {
        private int daylist;

        public ObservableCollection<NotificationPanel> NotificationPanels { get; set; }
        public ICommand SelectedNotificationCommand { get; set; }

        private NotificationPanel _selectedNotification;
        public NotificationPanel SelectedNotification
        {
            get => _selectedNotification;
            set => SetProperty(ref _selectedNotification, value);
        }

        public ControlPandelViewModel() { }

        public ControlPandelViewModel(Person infor)
        {
            daylist = 1000;

            // Load dữ liệu từ dịch vụ
            NotificationPanels = new ControlPanelService().GetAllDeadline(infor.IdPerson, daylist);

            // Khởi tạo Command
            SelectedNotificationCommand = new RelayCommand<NotificationPanel>(ShowElement);
        }

        // Logic để hiển thị thông tin
        private void ShowElement(NotificationPanel notificationPanel)
        {
            if (notificationPanel == null) return;

            ElementSection inforElement = new ElementSection(
                notificationPanel.IdElement,
                notificationPanel.NameElement,
                notificationPanel.TypeElement,
                notificationPanel.IdCourse,
                notificationPanel.IdSection,
                notificationPanel.IdStudent
            );

            switch (notificationPanel.TypeElement)
            {
                case "Test":
                    new Quiz(inforElement).Show();
                    break;
                case "Assignment":
                    new AssignmentStudentWView(inforElement).Show();
                    break;
                default:
                    break;
            }
        }

     
    }

}
