using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.Models
{
    public class OverviewLectureCourse
    {
        public int IdPerson { get; set; }
        public int IdCourse { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NameCourse { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImgCourse { get; set; }
    }
}

