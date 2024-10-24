using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class StudentAn
    {
        public int IdAns { get; set; }
        public string? StudentAns { get; set; }
        public int? IdStudent { get; set; }
        public int? IdQues { get; set; }

        public virtual Question? IdQuesNavigation { get; set; }
        public virtual Student? IdStudentNavigation { get; set; }
    }
}
