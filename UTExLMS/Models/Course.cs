using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseStudents = new HashSet<CourseStudent>();
            Sections = new HashSet<Section>();
            IdLecturers = new HashSet<Person>();
        }

        public int IdCourse { get; set; }
        public string? NameCourse { get; set; }
        public int? IdSubject { get; set; }
        public int? IdLecturer { get; set; }
        public string? ImgCourse { get; set; }

        public virtual Person? IdLecturerNavigation { get; set; }
        public virtual Subject? IdSubjectNavigation { get; set; }
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
        public virtual ICollection<Section> Sections { get; set; }

        public virtual ICollection<Person> IdLecturers { get; set; }
    }
}
