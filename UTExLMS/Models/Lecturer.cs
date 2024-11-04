using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            Comments = new HashSet<Comment>();
            Courses = new HashSet<Course>();
        }

        public int IdLecturer { get; set; }
        public string? Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Gender { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? PhoneNum { get; set; }
        public int? IdRole { get; set; }
        public string? Pass { get; set; }

        public virtual Role? IdRoleNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
