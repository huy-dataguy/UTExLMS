using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Question
    {
        public Question()
        {
            StudentAns = new HashSet<StudentAn>();
        }

        public int IdQues { get; set; }
        public string? NameQues { get; set; }
        public string? A { get; set; }
        public string? B { get; set; }
        public string? C { get; set; }
        public string? D { get; set; }
        public string? TrueAns { get; set; }
        public int? IdTest { get; set; }

        public virtual Test? IdTestNavigation { get; set; }
        public virtual ICollection<StudentAn> StudentAns { get; set; }
    }
}
