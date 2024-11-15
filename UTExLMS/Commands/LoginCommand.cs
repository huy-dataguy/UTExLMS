using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.ViewModels;
using System.Windows;

namespace UTExLMS.Commands
{
    internal class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }
        public override void Execute(object? parameter)
        {
            MessageBox.Show(_loginViewModel.Password,_loginViewModel.Email);
        }
    }
}
