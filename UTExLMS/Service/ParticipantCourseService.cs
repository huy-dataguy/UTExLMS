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


        public ObservableCollection<Person> GetParticipantStudent(int idCourse)
        {

            ObservableCollection<Person> participantsStudent = new ObservableCollection < Person > (_context.People
        .FromSqlRaw($"SELECT * FROM GetStudentsByCourse({idCourse})")
        .Include(p => p.IdRoleNavigation)  
        .ToList());

            return participantsStudent;
        }


    }
}
