using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using HandyControl.Tools.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.Xaml.Behaviors.Media;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    public class StudentClassService
    {
        private readonly UTExLMSContext _context;
        public List<OverviewClass> OverviewClasses { get; set; }


        public StudentClassService(UTExLMSContext context, int idStudent, string status, string searchTerm)
        {
            _context = context;
            OverviewClasses = GetStudentClassByStatus(idStudent, status, searchTerm);
        }

        public List<OverviewClass> GetStudentClassByStatus(int idstudent, string status, string searchTerm)
        {
            //var parameterIdStudent = new SqlParameter("@studentId", idstudent);
            //var parameterStatus = new SqlParameter("@status", status.ToString())
            //List<OverviewClass> classes = _context.OverviewClasses
            //    .FromSqlRaw("SELECT * FROM GetStudentCoursesByStatus(@studentId, @status)", parameterIdStudent, parameterStatus)
            //    .ToList();

            List<OverviewClass> classes = _context.OverviewClasses
                .FromSqlRaw($"SELECT * FROM GetCourses({idstudent}, '{status}', '{searchTerm}')")
                .ToList();



            foreach (OverviewClass classInfo in classes)
            {
                classInfo.ImgClass = GetImagePath(); 
            }

            return classes;
        }

        private string GetImagePath()
        {
            string path = Environment.CurrentDirectory;
            string path1 = Directory.GetParent(path).Parent.Parent.FullName;
            return Path.Combine(path1, "Assets", "course.png");
        }


    }
}
