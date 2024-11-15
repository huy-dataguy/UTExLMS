using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Printing;
using System.Linq;
using HandyControl.Tools.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.Xaml.Behaviors.Media;
using UTExLMS.Models;
using System.Windows;

namespace UTExLMS.Service
{
    public class StudentCourseService
    {
        private readonly Addition _addition;
        


        public StudentCourseService()
        {
            _addition = new Addition();
        }

        public ObservableCollection<OverviewCourse> GetCourses(int idStudent, string searchTerm = "", string selectedFilter = "All")
        {
            var courses = _addition.OverviewCourses
                .FromSqlRaw($"SELECT * FROM GetCourses({idStudent}, '{searchTerm}', '{selectedFilter}')")
                .ToList();

            foreach (OverviewCourse courseInfo in courses)
            {
                courseInfo.ImgCourse = GetImagePath();
            }
            return new ObservableCollection<OverviewCourse>(courses);
        }


        public ObservableCollection<OverviewLectureCourse> GetCoursesLecture(int idStudent, string searchTerm = "", string selectedFilter = "All")
        {
            MessageBox.Show($"SELECT * FROM GetCourseLecture({idStudent}, '{searchTerm}', '{selectedFilter}')");
            
            var courses = _addition.OverviewLectureCourses
                .FromSqlRaw($"SELECT * FROM GetCourseLecture({idStudent}, '{searchTerm}', '{selectedFilter}')")
                .ToList();

            foreach (OverviewLectureCourse courseInfo in courses)
            {
                courseInfo.ImgCourse = GetImagePath();
            }
            return new ObservableCollection<OverviewLectureCourse>(courses);
        }


        private string GetImagePath()
        {
            string path = Environment.CurrentDirectory;
            string path1 = Directory.GetParent(path).Parent.Parent.FullName;
            return Path.Combine(path1, "Assets", "course.png");
        }
    }
}
