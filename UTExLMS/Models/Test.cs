using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Test
    {
        public Test()
        {
            Questions = new HashSet<Question>();
        }

        public int IdTest { get; set; }
        public string? NameTest { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TimeLimit { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public int? IdSection { get; set; }
        public int? IdLecturer { get; set; }

        public virtual Lecturer? IdLecturerNavigation { get; set; }
        public virtual Section? IdSectionNavigation { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
