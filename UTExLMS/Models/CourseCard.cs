using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public class CourseCard
    {

        public string Header { get; set; }

        public string Content { get; set; }

        public string Footer { get; set; }
        public CourseCard(string header, string content, string footer)
        {
            this.Header = header;
            this.Content = content;
            this.Footer = footer;
        }
        public CourseCard() { }


    }
}
