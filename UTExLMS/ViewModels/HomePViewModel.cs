using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace UTExLMS.ViewModels
{
    internal class HomePViewModel : ViewModelBase
    {
        private string _currentDate;
        public string CurrentDate
        {
            get { return _currentDate; }
            set { SetProperty(ref _currentDate, value); }
        }

        private string currentTime;

        public string CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }

        public HomePViewModel()
        {
            CurrentDate = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, e) => CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();


        }


       
    }

}
