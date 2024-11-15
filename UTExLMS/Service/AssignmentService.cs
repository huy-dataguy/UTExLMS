using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    class AssignmentService
    {
        private UTExLMSContext _context;
        private Addition _addition;

        public AssignmentService()
        {
            _context = new UTExLMSContext();
            _addition = new Addition();
        }
        public ObservableCollection<AssignmentStudent> GetAssignmentStudents(int idStudent, int idCourse, int idSection, int idAssignment )
        {
            var assignments = _addition.AssignmentStudents.FromSqlRaw($"select * from GetStudentAssignment({idStudent},{idCourse},{idSection},{idAssignment})").ToList();
            MessageBox.Show($"select * from GetStudentAssignment({idStudent},{idCourse},{idSection},{idAssignment}");
            return new ObservableCollection<AssignmentStudent>(assignments);
        }
        public void CreateAssignment(int idSection, int idCourse, string nameAssign, string descript, DateTime startDate, DateTime endDate)
        {
            // Tạo parameters để truyền vào thủ tục
            var parameters = new[]
            {
        new SqlParameter("@nameAssign", SqlDbType.VarChar) { Value = nameAssign },
        new SqlParameter("@statu", SqlDbType.Bit) { Value = 0 },  // Giá trị mặc định là 0
        new SqlParameter("@startDate", SqlDbType.Date) { Value = startDate },
        new SqlParameter("@endDate", SqlDbType.Date) { Value = endDate },
        new SqlParameter("@descript", SqlDbType.VarChar) { Value = descript },
        new SqlParameter("@grade", SqlDbType.Float) { Value = 0 },  // Giá trị mặc định là 0
        new SqlParameter("@idSection", SqlDbType.Int) { Value = idSection },
        new SqlParameter("@idCourse", SqlDbType.Int) { Value = idCourse }
    };

            // Thực thi thủ tục
            _context.Database.ExecuteSqlRaw("EXEC AddAssignment @nameAssign, @statu, @startDate, @endDate, @descript, @grade, @idSection, @idCourse", parameters);
        }


        public Assignment GetAssignment(int idCourse, int idSection, int idElement)
        {
            var assignment = _context.Assignments
                .FromSqlRaw("SELECT * FROM GetAssignmentByElement({0}, {1}, {2})", idCourse, idSection, idElement)
                .FirstOrDefault();

            return assignment;
        }

     


        public void UpdateStudentAssignment(ElementSection inforElement, Assignment assignment,  string filePath, DateTime dateSubmit)
        {
            _context.Database.ExecuteSqlRaw(
                "EXEC UpdateStudentAssignment @nameFile = {0}, @pathFile = {1}, @typeFile = {2}, @dateSubmit = {3}, @idCourse = {4}, @idSection = {5}, @idAssign = {6}, @idStudent = {7}",
                assignment.NameAssign, // Lấy tên file từ đường dẫn
                filePath,
                Path.GetExtension(filePath),
                dateSubmit,
                inforElement.IdCourse,
                inforElement.IdSection,
                assignment.IdAssign,
                inforElement.IdStudent
            );

        }



    

    public StudentAssignment GetAssignmentSubmited(int idCourse, int idSection, int idElement, int idStudent)
        {

            var assignmentSubmited = _context.StudentAssignments
              .FromSqlRaw("SELECT * FROM GetAssignmentSubmited({0}, {1}, {2}, {3})", idCourse, idSection, idElement, idStudent)
              .FirstOrDefault();

            return assignmentSubmited;
        }
    }
}
