using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Test
    {
        public Test()
        {
            Questions = new HashSet<Question>();
            StudentTests = new HashSet<StudentTest>();
        }

        public int IdTest { get; set; }
        public string? NameTest { get; set; }
        public bool? Statu { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TimeLimit { get; set; }
        public string? Descript { get; set; }
        public int IdSection { get; set; }
        public int IdCourse { get; set; }

        public virtual Element Id { get; set; } = null!;
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<StudentTest> StudentTests { get; set; }
    }
}
