using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    public class NotifyService
    {
        private Addition _addition;
        public NotifyService()
        {
            _addition = new Addition();
        }
        public ObservableCollection<Notify> GetUpcomingDeadlinesForStudent(int idStudent)
        {
            var notifications = _addition.Notifys
                .FromSqlRaw($"SELECT * FROM GetUpcomingDeadlinesForStudent({idStudent})")
                .ToList();

            return new ObservableCollection<Notify>(notifications);
        }
    }
}
