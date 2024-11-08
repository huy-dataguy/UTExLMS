using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UTExLMS.Commands;
using UTExLMS.Models;
using UTExLMS.Service;
using UTExLMS.ViewModels.UCViewModel;

namespace UTExLMS.ViewModels
{
    internal class AddTestWViewModel : ViewModelBase
    {
        public Action closeAction { get; set; }

        private string _nameTest { get; set; }

        public string NameTest
        {
            get => _nameTest;
            set
            {
                _nameTest = value;
                OnPropertyChanged(nameof(NameTest));
            }
        }

        private string _descript { get; set; }

        public string Descript
        {
            get => _descript;
            set
            {
                _descript = value;
                OnPropertyChanged(nameof(Descript));
            }
        }

        private DateTime _startDate { get; set; }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _endDate { get; set; }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        private string _timeLimit { get; set; }

        public string TimeLimit
        {
            get => _timeLimit;
            set
            {
                _timeLimit = value;
                OnPropertyChanged(nameof(TimeLimit));
            }
        }

        private SectionUCViewModel _sectionUCViewModel { get; set; }

        private Test _test { get; set; }

        public ICommand AddQuestion { get; set; }
        public AddTestWViewModel()
        {
            AddQuestion = new RelayCommand(_ => AddNewQuestion());
        }

        public ICommand UpdateTestInfo { get; set; }

        public AddTestWViewModel(SectionUCViewModel sectionUCViewModel, Test test)
        {
            _sectionUCViewModel = sectionUCViewModel;
            _test = test;
            NameTest = test.NameTest ?? string.Empty;
            Descript = test.Descript ?? string.Empty;
            StartDate = test.StartDate ?? DateTime.Now;
            EndDate = test.EndDate ?? DateTime.Now;
            TimeLimit = test.TimeLimit?.ToString() ?? string.Empty;
            AddQuestion = new RelayCommand(_ => AddNewQuestion());
            UpdateTestInfo = new RelayCommand(_ => UpdateTest());
            UpdateQuestions();
        }


        private ObservableCollection<Question> _questions { get; set; }
        public ObservableCollection<Question> Questions
        {
            get => _questions;
            set
            {
                _questions = value;
                OnPropertyChanged(nameof(Questions));
            }
        }

        private ObservableCollection<QuestionUCViewModel> _questionUCViewModels { get; set; }

        public ObservableCollection<QuestionUCViewModel> QuestionUCViewModels
        {
            get => _questionUCViewModels;
            set
            {
                _questionUCViewModels = value;
                OnPropertyChanged(nameof(QuestionUCViewModels));
            }
        } 
        public void AddNewQuestion()
        {
           QuestionService questionService = new QuestionService();
           questionService.AddQuestion("Name", "Option1", "Option2", "Option3", "Option4","A",_test.IdTest,_test.IdCourse, _test.IdSection);
            UpdateQuestions();
        }

        public void UpdateQuestions()
        {
            QuestionService questionService = new QuestionService();
            _questions = questionService.GetQuestions(_test.IdTest,_test.IdSection,_test.IdCourse);
            _questionUCViewModels = new ObservableCollection<QuestionUCViewModel>();
            foreach (var question in _questions)
            {
                _questionUCViewModels.Add(new QuestionUCViewModel(question));
            }
            OnPropertyChanged(nameof(QuestionUCViewModels));
        }
        public void UpdateTest()
        {
            TestService testService = new TestService();
            testService.UpdateTest(_test.IdTest, _nameTest, 0, _startDate, _endDate, int.Parse(_timeLimit), _descript, _test.IdSection, _test.IdCourse);
            MessageBox.Show("Update test successful");
        }

    }
}
