using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.ViewModels
{
    public class CourseViewModel : ViewModelBase
    {
        private readonly Class _class;
        public int IdClass => _class.IdClass;
        public string? NameClass => _class.NameClass;

        public double? Progress => _class.Progress;
        public int? IdStudent => _class.IdStudent;
        public int? IdSubject => _class.IdSubject;
        public int? IdLecturer => _class.IdLecturer;

        public CourseViewModel(Class _class) 
        {
            _class = _class;
        }

    }
}
