using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Subjects = new HashSet<Subject>();
        }

        public int IdSemester { get; set; }
        public string? NameSemester { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
