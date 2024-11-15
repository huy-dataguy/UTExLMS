using CommunityToolkit.Mvvm.Input;
using HandyControl.Tools.Extension;
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
    internal class ResultViewModel : ViewModelBase
    {
        private Test _test { get; set; }
        private int _idStudent { get; set; }
        public ObservableCollection<Result> Results { get; set; }
        public ObservableCollection<ResultUCViewModel> ResultList { get; set; }


        public ResultViewModel()
        {
            QuestionService questionService = new QuestionService();
            Results = questionService.GetResults(101, 1001, 1, 1);
            UpdateQuestions();
        }

        public void UpdateQuestions()
        {
            ResultList = new ObservableCollection<ResultUCViewModel>();
            foreach (Result result in Results)
            {
                ResultList.Add(new ResultUCViewModel(result));
            }
        }


    }
}
