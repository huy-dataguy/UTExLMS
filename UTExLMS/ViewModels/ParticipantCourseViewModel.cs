using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;
using UTExLMS.Service;

namespace UTExLMS.ViewModels
{
    public class ParticipantCourseViewModel
    {
        public ObservableCollection<StudentWithRole> Paticipants { get; set; }

        public ParticipantCourseViewModel()
        {
            //Paticipants = new ParticipantCourseService().GetParticipantStudent(2);
        }
    }
}
