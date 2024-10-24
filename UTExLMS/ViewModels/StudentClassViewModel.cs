using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UTExLMS.Models;

namespace UTExLMS.ViewModels
{
    public class StudentClassViewModel
    {
        private readonly UTExLMSContext _context;

        public ObservableCollection<VwStudentCourse> StudentCourses { get; set; }
        public ICommand LoadCoursesCommand { get; }

        public StudentClassViewModel() { }
        public StudentClassViewModel (UTExLMSContext context)
        {
            _context = context;
            StudentCourses = new ObservableCollection<VwStudentCourse>();
            LoadCoursesCommand = new RelayCommand(LoadStudentCourses);
        }
        private void LoadStudentCourses()
        {
            var studentId = 1;
            var courses = _context.VwStudentCourses
                .Where(c => c.IdStudent == studentId)
                .ToList();

            StudentCourses.Clear();
            foreach (var course in courses)
            {
                StudentCourses.Add(course);
            }
        }
    }
}
