using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Views;

namespace UTExLMS.ViewModels
{
    public class StudentCourseDetailViewModel : ViewModelBase
    {
        private object _content;
        public object Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public StudentCourseDetailViewModel()
        {
            //Content = new ParticipantCoursePView();
            Content = new ListSectionStudentPView();
        }
    }
}
