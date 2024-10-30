using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            AssignmentStudents = new HashSet<AssignmentStudent>();
            Submissions = new HashSet<Submission>();
        }

        public int IdAssign { get; set; }
        public string? NameAssign { get; set; }
        public bool? Statu { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Descript { get; set; }
        public double? Grade { get; set; }
        public int? IdSection { get; set; }
        public int? IdLecturer { get; set; }

        public virtual Lecturer? IdLecturerNavigation { get; set; }
        public virtual Section? IdSectionNavigation { get; set; }
        public virtual ICollection<AssignmentStudent> AssignmentStudents { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
