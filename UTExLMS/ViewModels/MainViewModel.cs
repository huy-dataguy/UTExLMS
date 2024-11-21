using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using UTExLMS.Models;
using UTExLMS.ViewModels;
using UTExLMS.Views;

namespace UTExLMS.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _body;
        private string _logoUtex;

        public ICommand OpenProfile {  get; set; }
        public ICommand Notify { get; set; }
        private Person _person { get; set; }
        public string logoUtex
        {
            get
            {
                string path = Environment.CurrentDirectory;
                string path1 = Directory.GetParent(path).Parent.Parent.FullName;
                return path1 + "\\Assets\\ute_logo.png";
            }
        }

        private string _ringIcon;
        public string ringIcon
        {
            get
            {
                string path = Environment.CurrentDirectory;
                string path1 = Directory.GetParent(path).Parent.Parent.FullName;
                return path1 + "\\Assets\\BellGray.png";
            }
        }

        private string _avatar;
        public string avatar
        {
            get
            {
                string path = Environment.CurrentDirectory;
                string path1 = Directory.GetParent(path).Parent.Parent.FullName;
                return path1 + "\\Assets\\avatar.png";
            }
        }



        public ICommand Home { get; }
        public ICommand MyCourse { get; }
        public ICommand ControlPanel { get; }


        public object Body
        {
            get => _body;
            set
            {
                _body = value;
                OnPropertyChanged(nameof(Body));
            }
        }
        public MainViewModel(Person person)

        {
            _person = person;

            if (person.IdRole == 2)
            {
                Body = new ListCourseLecturePView(this, person);


            }
            else
            {
                Body = new ListCourseView(this, person);
                Home = new RelayCommand(HomePage);
                MyCourse = new RelayCommand(MyCoursePage);
                ControlPanel = new RelayCommand(ControlPanelPage);
                Notify = new RelayCommand(OpenNotifyPage);


            }


        }
        private void HomePage()
        {
            Body = new HomePView();
        }

        private void ControlPanelPage()
        {
            Body = new ControlPanelPView(_person);
        }

        private void MyCoursePage()
        {
            Body = new ListCourseView(this, _person);
        }



        private void OpenProfilePage()
        {
            ProfilePView profilePView = new ProfilePView();
            profilePView.Show();
            
        }

        private void OpenNotifyPage()
        {
            NotifyView notifyView = new NotifyView(_person.IdPerson);
            notifyView.Show();
        }

    }
}




