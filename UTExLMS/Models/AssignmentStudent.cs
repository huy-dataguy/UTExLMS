using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class AssignmentStudent
    {
        //public int IdAssign { get; set; }
        //public int IdStudent { get; set; }
        //public int? NumAttempts { get; set; }
        //public double? TotalScore { get; set; }
        //public int? TotalTimeSpent { get; set; }

        //public virtual Assignment IdAssignNavigation { get; set; } = null!;
        //public virtual Student IdStudentNavigation { get; set; } = null!;
        public int IdAssign { get; set; }
        public int IdStudent { get; set; }
        public string? NameAssign { get; set; }
        public bool? Statu { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Descript { get; set; }
        public double? Grade { get; set; }
        public int? NumAttempts { get; set; }
        public double? TotalScore { get; set; }
        public int? TotalTimeSpent { get; set; }

        public virtual Assignment IdAssignNavigation { get; set; } = null!;
        public virtual Person  IdStudentNavigation { get; set; } = null!;
    }
}
