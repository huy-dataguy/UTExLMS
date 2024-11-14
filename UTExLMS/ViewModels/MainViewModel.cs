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
using UTExLMS.Views;

namespace UTExLMS.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _body;
        private string _logoUtex;

        public ICommand OpenProfile {  get; set; }
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



        public object Body
        {
            get => _body;
            set
            {
                _body = value;
                OnPropertyChanged(nameof(Body));
            }
        }
        public MainViewModel()
        {
            Body = new Quiz();
        }
        private void OpenProfilePage()
        {
            ProfilePView profilePView = new ProfilePView();
            profilePView.Show();
            
        }
    }
}
