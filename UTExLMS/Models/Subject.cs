using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Course>();
        }

        public int IdSubject { get; set; }
        public string? NameSubject { get; set; }
        public int? IdSemester { get; set; }

        public virtual Semester? IdSemesterNavigation { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
