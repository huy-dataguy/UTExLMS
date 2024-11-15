using CommunityToolkit.Mvvm.Input;
using HandyControl.Tools.Extension;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using UTExLMS.Models;
using UTExLMS.Service;
using UTExLMS.ViewModels.UCViewModel;
using UTExLMS.Views;
using UTExLMS.Views.UserControlView;

namespace UTExLMS.ViewModels
{
    internal class QuestionListViewModel : ViewModelBase
    {

        private ElementSection _elementInfor {  get; set; }
        private Test _test { get; set; }
        private int _idStudent {  get; set; }
        public ObservableCollection<Question> Questions {  get; set; }
        public ObservableCollection<QuestionListUCViewModel> QuestionsList {  get; set; }

        public ICommand Submit {  get; set; }

        public QuestionListViewModel(ElementSection inforElement)  
        {
            _elementInfor = inforElement;
            Submit = new RelayCommand(CalculateStudentScore);
            QuestionService questionService = new QuestionService();
            Questions = questionService.GetQuestions(inforElement.IdElement, inforElement.IdSection, inforElement.IdCourse);
            UpdateQuestions();
        }

        public void UpdateQuestions()
        {
            QuestionsList = new ObservableCollection<QuestionListUCViewModel>();
            foreach (Question question in Questions)
            {
                QuestionsList.Add(new QuestionListUCViewModel(question, _elementInfor));
            }
            OnPropertyChanged(nameof(QuestionsList));
        }

        private void CalculateStudentScore()
        {
            CalculateScoreService calculateScoreService = new CalculateScoreService();
            calculateScoreService.CalculateScore(_elementInfor.IdStudent, _elementInfor.IdCourse, _elementInfor.IdSection, _elementInfor.IdElement);

        }
    }
}
