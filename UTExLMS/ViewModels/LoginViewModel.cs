using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UTExLMS.Commands;
namespace UTExLMS.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _password;
        private bool _isStudent;

        // Properties for Email, Password, and UserType (Student/Teacher)
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

        public bool IsStudent
        {
            get => _isStudent;
            set
            {
                _isStudent = value;
                OnPropertyChanged();
            }
        }

        // Command to handle the Login action
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new LoginCommand(this);
        }

        // Method for the Login action
        private void Login(object parameter)
        {
            // Implement login logic here
            if (IsStudent)
            {
                // Handle student login
            }
            else
            {
                // Handle teacher login
            }
        }
        public void UpdatePassword(string password)
        {
            Password = password;
        }

        // Determine if login is possible
        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}