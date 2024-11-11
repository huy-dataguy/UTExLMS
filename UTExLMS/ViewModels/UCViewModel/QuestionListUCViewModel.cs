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
using System.Windows.Input;
using UTExLMS.Commands;
using UTExLMS.Models;
using UTExLMS.Service;
namespace UTExLMS.ViewModels
{
    public class QuestionListUCViewModel : ViewModelBase
    {

        private string _selectedAnswer;
        private int _idStudent;
        
        private Question _question{  get; set; }
        private int _idQues;
        private string _nameQues;
        private string _A;
        private string _B;
        private string _C;
        private string _D;
        private string _trueAns;
        private int _idTest { get; set; }
        private int _idSection { get; set; }
        private int _idCourse { get; set; }

        public QuestionListUCViewModel() { }
        public QuestionListUCViewModel(Question question)
        {
            _question = question;
            _idQues = question.IdQues;
            _nameQues = question.NameQues;
            _A = question.A;
            _B = question.B;
            _C = question.C;
            _D = question.D;
            _trueAns = question.TrueAns;

            SelectAnswerCommand = new RelayCommand<string>(SelectAnswer);
        }

        public ICommand SelectAnswerCommand { get; }
        public ObservableCollection<Question> Questions { get; set; }

        public void SelectAnswer(string answer)
        {
            
            //SelectedAnswer = answer;
            //StudentAnswerService studentAnswerService = new StudentAnswerService();
            //studentAnswerService.AddStudentAnswer(SelectedAnswer, _idStudent, _test.IdCourse, _test.IdSection, _test.IdTest, _idQues);
            MessageBox.Show(answer);
        }
        public string SelectedAnswer
        {
            get => _selectedAnswer;
            set
            {
                _selectedAnswer = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
