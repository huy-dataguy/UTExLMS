using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    public class ControlPanelService
    {
        private Addition _addition {  get; set; }
        public ControlPanelService() {
            _addition = new Addition();
        }
        public ObservableCollection<NotificationPanel> GetAllDeadline(int idPerson, int days)
        {
           

            var deadline = _addition.NotificationPanels
                .FromSqlRaw($"SELECT * FROM dbo.GetNotificationsByStudentAndDateRange({idPerson}, {days})")
                .ToList();

            return new ObservableCollection<NotificationPanel>(deadline);
        }

    }
   
}
