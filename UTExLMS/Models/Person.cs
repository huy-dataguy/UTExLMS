using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Person
    {
        public Person()
        {
            Comments = new HashSet<Comment>();
            CourseStudents = new HashSet<CourseStudent>();
            Courses = new HashSet<Course>();
            StudentAns = new HashSet<StudentAn>();
            StudentAssignments = new HashSet<StudentAssignment>();
            StudentTests = new HashSet<StudentTest>();
            IdCourses = new HashSet<Course>();
            Ids = new HashSet<Element>();
        }

        public int IdPerson { get; set; }
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
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<StudentAn> StudentAns { get; set; }
        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }
        public virtual ICollection<StudentTest> StudentTests { get; set; }

        public virtual ICollection<Course> IdCourses { get; set; }
        public virtual ICollection<Element> Ids { get; set; }
    }
}
