using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class StudentAssignment
    {
        public string? NameFile { get; set; }
        public string? PathFile { get; set; }
        public string? TypeFile { get; set; }
        public DateTime? DateSubmit { get; set; }
        public int IdCourse { get; set; }
        public int IdSection { get; set; }
        public int IdAssign { get; set; }
        public int IdStudent { get; set; }

        public virtual Assignment Id { get; set; } = null!;
        public virtual Person IdStudentNavigation { get; set; } = null!;
    }
}
