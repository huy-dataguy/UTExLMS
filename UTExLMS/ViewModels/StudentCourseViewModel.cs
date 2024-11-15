using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
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

        public ObservableCollection<OverviewLectureCourse> LectureCourses { get; private set; }


        private MainViewModel _mainViewModel;

        public MainViewModel MainViewModel
        {
            get { return _mainViewModel; }
            set 
            { 
                _mainViewModel = value; 
            }
        }

        private Person _person { get; set; }

        private string _selectedFilter;

        private string _searchTerm;
        
        public ICommand SearchCmd { get; }

        public ICommand GoToCourse { get; }
        public ICommand GoToCourseLecture { get; }

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

        public StudentCourseViewModel(MainViewModel mainViewModel, Person person)
        {
            _person = person;
            FilterOption = new FilterListCourse();
            _selectedFilter = FilterOption.SelectedName[0];
            SearchCmd = new RelayCommand(UpdateStudentCourses);

            GoToCourse = new RelayCommand<OverviewCourse>(GoCourse);

            GoToCourseLecture = new RelayCommand<OverviewLectureCourse>(GoCourseLecture);
            _mainViewModel = mainViewModel;

            if (_person.IdRole == 2)
                LectureCourses = new StudentCourseService().GetCoursesLecture(_person.IdPerson);
            else

                StudentCourses = new StudentCourseService().GetCourses(_person.IdPerson);




        }

        private void UpdateStudentCourses()
        {

            StudentCourseService studentCourseService = new StudentCourseService();
            if (_person.IdRole == 2)
            {
                LectureCourses = studentCourseService.GetCoursesLecture(_person.IdPerson, _searchTerm, SelectedFilter);
                OnPropertyChanged(nameof(LectureCourses));
            }
            else
            {
                StudentCourses = studentCourseService.GetCourses(_person.IdPerson, _searchTerm, SelectedFilter);
                OnPropertyChanged(nameof(StudentCourses));
            }



        }

        private void GoCourse(OverviewCourse overviewCourse)
        {

          
                _mainViewModel.Body = new StudentCourseDetailPView(overviewCourse);
            


        }
        private void GoCourseLecture(OverviewLectureCourse overviewCourse)
        {

            _mainViewModel.Body = new LectureCoursePView(overviewCourse);
            MessageBox.Show("HELLOO");
        }
    }
}
