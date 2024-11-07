using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Comment
    {
        public int IdCmt { get; set; }
        public string? Content { get; set; }
        public DateTime? CommentDate { get; set; }
        public int? IdCourse { get; set; }
        public int? IdSection { get; set; }
        public int? IdDiscuss { get; set; }
        public int? IdPerson { get; set; }

        public virtual Discussion? Id { get; set; }
        public virtual Person? IdPersonNavigation { get; set; }
    }
}
