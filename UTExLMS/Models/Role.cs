using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Role
    {
        public Role()
        {
            Lecturers = new HashSet<Lecturer>();
            Students = new HashSet<Student>();
        }

        public int IdRole { get; set; }
        public string? NameRole { get; set; }

        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
