using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Comment
    {
        public int IdCmt { get; set; }
        public string? Content { get; set; }
        public int? IdDiscuss { get; set; }
        public int? IdStudent { get; set; }
        public int? IdLecturer { get; set; }

        public virtual Discussion? IdDiscussNavigation { get; set; }
        public virtual Lecturer? IdLecturerNavigation { get; set; }
        public virtual Student? IdStudentNavigation { get; set; }
    }
}
