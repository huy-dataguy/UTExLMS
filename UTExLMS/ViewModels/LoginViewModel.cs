using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UTExLMS.Commands;
using UTExLMS.Models;
using UTExLMS.Service;
namespace UTExLMS.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _password;
        private Person _person;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(_ => Login());
        }

        private void Login()
        {
            ProfileService profileService = new ProfileService();
            _person = profileService.loginAuth(Email, Password);
            if (_person == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công");
            }
        }
        public void UpdatePassword(string password)
        {
            Password = password;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}