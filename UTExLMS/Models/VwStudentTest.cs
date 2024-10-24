using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class VwStudentTest
    {
        public int IdStudent { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NameTest { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
