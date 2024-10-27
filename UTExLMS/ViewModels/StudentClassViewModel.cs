using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using UTExLMS.Models;
using UTExLMS.Views.UserControlView;

namespace UTExLMS.ViewModels
{
    public class StudentClassViewModel : ViewModelBase
    {
        private readonly UTExLMSContext _context;

        public ObservableCollection<VwStudentCourse> _studentCourses { get; set; }

        public ObservableCollection<VwStudentCourse> StudentCourse => _studentCourses;

        public StudentClassViewModel(UTExLMSContext context)
        {
            _context = context;
            _studentCourses = LoadStudentCourses();
        }

        public StudentClassViewModel() { }

        private ObservableCollection<VwStudentCourse> LoadStudentCourses()
        {
            ObservableCollection<VwStudentCourse> _studentCourses = new ObservableCollection<VwStudentCourse>();
            var studentId = 1;

            try
            {
                var courses = _context.VwStudentCourses
                    .Where(c => c.IdStudent == studentId)
                    .ToList();

                if (courses.Count == 0)
                {
                    MessageBox.Show("No courses found for the selected student.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                foreach (var course in courses)
                {
                    // Assign the image path to the Img property of each course
                    course.Img = GetImagePath();
                    _studentCourses.Add(course);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading courses: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return _studentCourses;
        }

        // Helper method to retrieve the image path
        private string GetImagePath()
        {
            string path = Environment.CurrentDirectory;
            string path1 = Directory.GetParent(path).Parent.Parent.FullName;
            return Path.Combine(path1, "Assets", "course.png");
        }
    }
}
