using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Views;

namespace UTExLMS.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _body;
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
            Body = new ListCourseView();
        }
    }
}
