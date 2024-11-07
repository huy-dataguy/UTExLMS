using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class StudentAn
    {
        public int IdPerson { get; set; }
        public string? Ans { get; set; }
        public bool? IsTrue { get; set; }
        public int IdQues { get; set; }
        public int IdTest { get; set; }
        public int IdSection { get; set; }
        public int IdCourse { get; set; }

        public virtual Question Id { get; set; } = null!;
        public virtual Person IdPersonNavigation { get; set; } = null!;
    }
}
