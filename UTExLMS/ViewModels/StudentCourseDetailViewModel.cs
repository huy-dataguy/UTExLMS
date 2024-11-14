using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Views;
using UTExLMS.Commands;
namespace UTExLMS.ViewModels
{
    public class StudentCourseDetailViewModel : ViewModelBase
    {
        private object _contentCourse;
        public OverviewCourse OverviewCourses { get; }
        public object ContentCourse
        {
            get => _contentCourse;
            set
            {
                _contentCourse = value;
                OnPropertyChanged(nameof(ContentCourse));
            }
        }

        public ICommand ShowCourseCommand { get; }
        public ICommand ShowParticipantsCommand { get; }
        public ICommand ShowGradesCommand { get; }
        public StudentCourseDetailViewModel(OverviewCourse overviewCourse)
        {
            OverviewCourses = overviewCourse;
            ContentCourse = new ListSectionStudentPView(OverviewCourses);
            ShowCourseCommand = new RelayCommand<OverviewCourse>(ShowCourse);
            ShowParticipantsCommand = new RelayCommand<OverviewCourse>(ShowParticipants);
            ShowGradesCommand = new RelayCommand<OverviewCourse>(ShowGrades);
        }

        private void ShowCourse(OverviewCourse overviewCourse)
        {
            ContentCourse = new ListSectionStudentPView(overviewCourse);
        }

        private void ShowParticipants(OverviewCourse overviewCourse)
        {
            ContentCourse = new ParticipantCoursePView(overviewCourse); 
        }

        private void ShowGrades(OverviewCourse overviewCourse)
        {
            ContentCourse = new GradeStudentCoursePView(overviewCourse);
        }
    }
}
