using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;
using Microsoft.EntityFrameworkCore;
namespace UTExLMS.Service
{
    public class AssignmentStudentService
    {
        private readonly UTExLMSContext _context;
        public List<AssignmentStudent> AssignmentStudent { get; set; }

        public AssignmentStudentService(UTExLMSContext context, int idStudent)
        {
            _context = context;
            AssignmentStudent = GetAssignmentStudentsById( idStudent);
        }
        public List<AssignmentStudent> GetAssignmentStudentsById(int idstudent)
        {
            List<AssignmentStudent> assignment = _context.AssignmentStudents
            .FromSqlRaw($"SELECT * FROM GetStudentAssignments({1})")
            .ToList();

            return assignment;
        }
    }


}
