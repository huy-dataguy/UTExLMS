using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media; // Add this for Brushes and SolidColorBrush
using UTExLMS.Commands;
using UTExLMS.Models;
using UTExLMS.Service;
using System.Data.Entity;

namespace UTExLMS.ViewModels.UCViewModel
{
    internal class ResultUCViewModel : ViewModelBase
    {
        private string _selectedAnswer;
        private Question _question;
        private Result _result;
        public Brush ColorA { get; set; }
        public Brush ColorB { get; set; }
        public Brush ColorC { get; set; }
        public Brush ColorD { get; set; }


        public string NameQues { get; private set; }
        public string A { get; private set; }
        public string B { get; private set; }
        public string C { get; private set; }
        public string D { get; private set; }
        private string _trueAns;
        private string _Ans;

        public ResultUCViewModel() { }

        public ResultUCViewModel(Result result)
        {
            ColorA = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            ColorB = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            ColorC = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            ColorD = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            
            _result = result;
            NameQues = result.NameQues;
            A = result.A;
            B = result.B;
            C = result.C;
            D = result.D;
            _trueAns = result.TrueAns;
            _Ans = result.Ans;
            UpdateColor();
        }

        public void UpdateColor()
        {
            if (_Ans == "A")
            {
                ColorA = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
            }
            if (_Ans == "B")
            {
                ColorB = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
            }
            if (_Ans == "C")
            {
                ColorC = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
            }
            if (_Ans == "D")
            {
                ColorD = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
            }
            if (_trueAns == "A")
            {
                ColorA = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
            }
            if (_trueAns == "B")
            {
                ColorB = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
            }
            if (_trueAns == "C")
            {
                ColorC = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
            }
            if (_trueAns == "D")
            {
                ColorD = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
            }

        }
        public ObservableCollection<Question> Questions { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
