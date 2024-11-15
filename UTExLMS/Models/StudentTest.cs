using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class StudentTest
    {
        public int IdStudent { get; set; }
        public int IdCourse { get; set; }
        public int IdSection { get; set; }
        public int IdTest { get; set; }
        public double? TotalScore { get; set; }

        public virtual Test Id { get; set; } = null!;
        public virtual Person IdStudentNavigation { get; set; } = null!;
    }
}
