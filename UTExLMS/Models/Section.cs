using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Section
    {
        public Section()
        {
            Assignments = new HashSet<Assignment>();
            Discussions = new HashSet<Discussion>();
            Elements = new HashSet<Element>();
        }

        public int IdSection { get; set; }
        public int IdCourse { get; set; }
        public string? NameSection { get; set; }
        public string? Descript { get; set; }

        public virtual Course IdCourseNavigation { get; set; } = null!;
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<Element> Elements { get; set; }
    }
}
