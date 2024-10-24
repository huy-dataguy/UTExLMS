using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Class
    {
        public Class()
        {
            Sections = new HashSet<Section>();
        }

        public int IdClass { get; set; }
        public string? NameClass { get; set; }
        public double? Progress { get; set; }
        public int? IdStudent { get; set; }
        public int? IdSubject { get; set; }
        public int? IdLecturer { get; set; }

        public virtual Lecturer? IdLecturerNavigation { get; set; }
        public virtual Student? IdStudentNavigation { get; set; }
        public virtual Subject? IdSubjectNavigation { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
