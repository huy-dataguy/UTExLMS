using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;
using UTExLMS.Service;

namespace UTExLMS.ViewModels.UCViewModel
{
    internal class QuestionUCViewModel : ViewModelBase
    {
        private Question _question { get; set; }

        private ObservableCollection<String> _options { get; set; }

        public ObservableCollection<string> Options
        {
            get => _options;
            set
            {
                _options = value;
            }
            
                }
        private int _questionNumber { get; set; }

        public int QuestionNumber
        {
            get => _questionNumber;
            set
            {
                _questionNumber = value;
                OnPropertyChanged(nameof(QuestionNumber));
            }
        }

        private string _nameQues { get; set; }

        public string NameQues
        {
            get => _nameQues;
            set
            {
                _nameQues = value;
                UpdateQuestion();
                OnPropertyChanged(nameof(NameQues));
            }
        }

        private string _a { get; set; }

        public string A
        {
            get => _a;
            set
            {
                _a = value;
                UpdateQuestion();
                OnPropertyChanged(nameof(A));
            }
        }

        private string _b { get; set; }
        public string B
        {
            get => _b;
            set
            {
                _b = value;
                UpdateQuestion();
                OnPropertyChanged(nameof(B));
            }
        }
        private string _c { get; set; }
        public string C
        {
            get => _c;
            set
            {
                _c = value;
                UpdateQuestion();
                OnPropertyChanged(nameof(C));
            }
        }
        private string _d { get; set; }
        public string D
        {
            get => _d;
            set
            {
                _d = value;
                UpdateQuestion();
                OnPropertyChanged(nameof(D));
            }
        }

        private string _trueAns { get; set; }
        public string TrueAns
        {
            get => _trueAns;
            set
            {
                _trueAns = value;
                UpdateQuestion();
                OnPropertyChanged(nameof(TrueAns));
            }
        }

        public QuestionUCViewModel(Question question)
        {
            _options = new ObservableCollection<string> { "A", "B", "C", "D" };
            _question = question;
            _questionNumber = question.IdQues;
            _a = _question.A;
            _b = _question.B;
            _c = _question.C;
            _d = _question.D;
            _trueAns = _question.TrueAns;
            _nameQues = _question.NameQues;
        }
        void UpdateQuestion()
        {
            QuestionService questionService = new QuestionService();
            questionService.UpdateQuestion(_question.IdQues, _nameQues, _a, _b, _c, _d, _trueAns, _question.IdTest, _question.IdCourse, _question.IdSection);
        }
    }
}
