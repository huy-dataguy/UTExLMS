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
using System.Data.Entity;
namespace UTExLMS.ViewModels
{
    public class QuestionListUCViewModel : ViewModelBase
    {
        private string _selectedAnswer;
        private Question _question;

        // Properties to bind in XAML, defined as auto-properties with private setters
        public int IdQues { get; private set; }
        public int IdTest {  get; private set; }
        public int IdCourse { get; private set; }

        public int IdSection { get; private set; }
        public string NameQues { get; private set; }
        public string A { get; private set; }
        public string B { get; private set; }
        public string C { get; private set; }
        public string D { get; private set; }
        private string _trueAns;

        public QuestionListUCViewModel() { }

        private ElementSection _elementInfor {  get;  set; }
        public QuestionListUCViewModel(Question question, ElementSection elementInfor)
        {
            _elementInfor = elementInfor;
            _question = question;
            IdQues = question.IdQues;
            IdTest = question.IdTest;
            IdCourse = question.IdCourse;
            IdSection = question.IdSection;
            NameQues = question.NameQues;
            A = question.A;
            B = question.B;
            C = question.C;
            D = question.D;
            _trueAns = question.TrueAns;

            SelectAnswerCommand = new RelayCommand<string>(SelectAnswer);
        }

        public ICommand SelectAnswerCommand { get; }
        public ObservableCollection<Question> Questions { get; set; }

        public void SelectAnswer(string answer)
        {
            SelectedAnswer = answer;
            QuestionService questionService = new QuestionService();
            questionService.AddStudentAnswer(answer, _elementInfor.IdStudent, _elementInfor.IdCourse, _elementInfor.IdSection, _elementInfor.IdElement, IdQues);
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