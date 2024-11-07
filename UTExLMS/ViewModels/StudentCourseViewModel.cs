using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Service;
using UTExLMS.Views;

namespace UTExLMS.ViewModels
{
    public class StudentCourseViewModel : ViewModelBase
    {
        public ObservableCollection<OverviewCourse> StudentCourses { get; private set; }

        private MainViewModel _mainViewModel;

        public MainViewModel MainViewModel
        {
            get { return _mainViewModel; }
            set 
            { 
                _mainViewModel = value; 
            }
        }

        private int _id = 3;

        private string _selectedFilter;

        private string _searchTerm;
        
        public ICommand SearchCmd { get; }

        public ICommand GoToCourse { get; }

        public FilterListCourse FilterOption { get; private set; }

        public string SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                if (SetProperty(ref _selectedFilter, value))
                {
                    SearchTerm = "";
                    UpdateStudentCourses();
                    OnPropertyChanged(nameof(SelectedFilter));
                }
            }
        }

        public string SearchTerm{ 
            get => _searchTerm;
            set
            {
                if (SetProperty(ref _searchTerm, value))
                {
                    if (_searchTerm != null) 
                        {
                            UpdateStudentCourses();
                        }
                }
            }
        }


        public StudentCourseViewModel() { }

        public StudentCourseViewModel(MainViewModel mainViewModel)
        { 
            FilterOption = new FilterListCourse();
            _selectedFilter = FilterOption.SelectedName[0];
            SearchCmd = new RelayCommand(UpdateStudentCourses);
            GoToCourse = new RelayCommand<OverviewCourse>(GoCourse);
            _mainViewModel = mainViewModel;
            StudentCourseService studentCourseService = new StudentCourseService();
            StudentCourses = studentCourseService.GetCourses(_id);
        }

        private void UpdateStudentCourses()
        {
            StudentCourseService studentCourseService = new StudentCourseService();
            StudentCourses = studentCourseService.GetCourses(_id, _searchTerm, SelectedFilter);
            OnPropertyChanged(nameof(StudentCourses));
        }

        private void GoCourse(OverviewCourse overviewCourse)
        {
            _mainViewModel.Body = new LectureCoursePView(overviewCourse);
        }
    }
}
