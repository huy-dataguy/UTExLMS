using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            StudentAssignments = new HashSet<StudentAssignment>();
        }

        public int IdAssign { get; set; }
        public string? NameAssign { get; set; }
        public bool? Statu { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Descript { get; set; }
        public double? Grade { get; set; }
        public int IdSection { get; set; }
        public int IdCourse { get; set; }

        public virtual Section Id { get; set; } = null!;
        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}
