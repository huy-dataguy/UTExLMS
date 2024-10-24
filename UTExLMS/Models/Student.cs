using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Student
    {
        public Student()
        {
            AssignmentStudents = new HashSet<AssignmentStudent>();
            Classes = new HashSet<Class>();
            Comments = new HashSet<Comment>();
            StudentAns = new HashSet<StudentAn>();
            Submissions = new HashSet<Submission>();
        }

        public int IdStudent { get; set; }
        public string? Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Gender { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? PhoneNum { get; set; }
        public int? IdRole { get; set; }
        public string? Password { get; set; }

        public virtual Role? IdRoleNavigation { get; set; }
        public virtual ICollection<AssignmentStudent> AssignmentStudents { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<StudentAn> StudentAns { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
