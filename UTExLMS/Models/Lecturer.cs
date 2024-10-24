using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            Assignments = new HashSet<Assignment>();
            Classes = new HashSet<Class>();
            Comments = new HashSet<Comment>();
            Discussions = new HashSet<Discussion>();
            Materials = new HashSet<Material>();
            Sections = new HashSet<Section>();
            Tests = new HashSet<Test>();
        }

        public int IdLecturer { get; set; }
        public string? Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Gender { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? PhoneNum { get; set; }
        public int? IdRole { get; set; }

        public virtual Role? IdRoleNavigation { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
