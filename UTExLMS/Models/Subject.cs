using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Classes = new HashSet<Class>();
        }

        public int IdSubject { get; set; }
        public string? NameSubject { get; set; }
        public int? IdSemester { get; set; }

        public virtual Semester? IdSemesterNavigation { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
