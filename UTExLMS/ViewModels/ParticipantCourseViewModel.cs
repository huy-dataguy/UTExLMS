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
    public class ParticipantCourseViewModel : ViewModelBase
    {
        public ObservableCollection<Person> Paticipants { get; set; }

        public ParticipantCourseViewModel(OverviewCourse overviewCourse)
        {
            Paticipants = new ParticipantStudentService().GetParticipantStudent(overviewCourse.IdCourse);
        }

    }
}
