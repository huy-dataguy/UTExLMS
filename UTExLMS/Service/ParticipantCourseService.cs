using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    public class ParticipantStudentService
    {
        private Addition _context;

        public ParticipantStudentService()
        {
            _context = new Addition();
        }


        //public ObservableCollection<Student> GetParticipantStudent(int idClass)
        //{
        //    ObservableCollection<Student> participantsStudent = new ObservableCollection<Student>(_context.Students
        //        .FromSqlRaw($"SELECT * FROM GetStudentsByClass({idClass})").ToList());


        //    return participantsStudent;
        //}


        //public ObservableCollection<StudentWithRole> GetParticipantStudent(int idCourse)
        //{
        //    //var studentWithRoles = new ObservableCollection<StudentWithRole>(
        //    //    _context.CourseStudents
        //    //        .FromSqlRaw("EXEC GetStudentsByCourse @idCourse = {0}", idCourse)
        //    //        .ToList()
        //    //);

        //    return studentWithRoles;
        //}

    }
}
