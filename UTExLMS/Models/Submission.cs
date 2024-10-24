using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Submission
    {
        public int IdSubmiss { get; set; }
        public string? NameFile { get; set; }
        public string? PathFile { get; set; }
        public string? TypeFile { get; set; }
        public DateTime? DateSubmit { get; set; }
        public int? IdAssign { get; set; }
        public int? IdStudent { get; set; }

        public virtual Assignment? IdAssignNavigation { get; set; }
        public virtual Student? IdStudentNavigation { get; set; }
    }
}
