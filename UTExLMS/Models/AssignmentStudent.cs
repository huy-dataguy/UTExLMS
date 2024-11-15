using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class AssignmentStudent
    {

        public int IdAssign { get; set; }
        public int IdStudent { get; set; }
        public string? NameAssign { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public AssignmentStudent()
        {

        }
    }
}
