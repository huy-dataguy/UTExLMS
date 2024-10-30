using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class ClassStudent
    {
        public int IdStudent { get; set; }
        public int IdClass { get; set; }
        public double? Progress { get; set; }

        public virtual Class IdClassNavigation { get; set; } = null!;
        public virtual Student IdStudentNavigation { get; set; } = null!;
    }
}
