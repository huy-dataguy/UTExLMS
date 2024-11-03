using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;
using UTExLMS.Service;

namespace UTExLMS.ViewModels
{
    class LectureCourseViewModel: ViewModelBase
    {
        private Class Class  { get; set; }
        public LectureCourseViewModel() { }
        
        public LectureCourseViewModel(OverviewCourse overviewCourse)
        {
            
   
        }
    }
}
