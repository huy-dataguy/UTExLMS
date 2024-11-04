using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Discussion
    {
        public Discussion()
        {
            Comments = new HashSet<Comment>();
        }

        public int IdDiscuss { get; set; }
        public string? Descript { get; set; }
        public string? NameDiscuss { get; set; }
        public int? IdSection { get; set; }
        public int? IdCourse { get; set; }

        public virtual Section? Id { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
