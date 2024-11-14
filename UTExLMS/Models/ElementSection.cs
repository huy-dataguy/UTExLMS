using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public class ElementSection
    {
        public int IdElement { get; set; }
        public string? ElementName { get; set; }
        public string? NameType { get; set; }

        public int IdCourse { get; set; }   
        public int IdSection { get; set; }

        public int IdStudent { get; set; }
        public ElementSection() { }
        public ElementSection(int idElement, string elementName, string nameType, int idCourse, int idSection, int IdStudent)
        {
            this.IdElement = idElement;
            this.ElementName = elementName;
            this.NameType = nameType;   
            this.IdCourse = idCourse;
            this.IdSection = idSection;
            this.IdStudent = IdStudent;
        }
    }
}
