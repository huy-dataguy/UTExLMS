using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.ViewModels;
using UTExLMS.Models;
using UTExLMS.Service;

namespace UTExLMS.ViewModels
{
    public class ParticipantCouseViewModel : ViewModelBase
    {
        public ObservableCollection<StudentWithRole> Paticipants { get; set; }

        public ParticipantCouseViewModel()
        {
            //Paticipants = new ParticipantCourseService().GetParticipantStudent(2);
        }
    }
}
