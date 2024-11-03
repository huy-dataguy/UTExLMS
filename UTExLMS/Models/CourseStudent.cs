using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class CourseStudent
    {
        public int IdStudent { get; set; }
        public int IdCourse { get; set; }
        public double? Progress { get; set; }

        public virtual Course IdCourseNavigation { get; set; } = null!;
        public virtual Student IdStudentNavigation { get; set; } = null!;
    }
}
