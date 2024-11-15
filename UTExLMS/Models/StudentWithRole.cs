using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public class StudentWithRole
    {
        public int IdPerson { get; set; }
        public string? Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Gender { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? PhoneNum { get; set; }
        public string? NameRole { get; set; }


        public StudentWithRole() { }

    }
}
