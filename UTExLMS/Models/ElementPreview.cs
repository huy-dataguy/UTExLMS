using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public  class ElementPreview
    {

        private int _idCourse { get; set; }
        
        public int IdCourse
        {
            get => _idCourse;
            set => _idCourse = value;
        }
        private int _idSection {  get; set; }

        public int IdSection
        {
            get => _idSection;
            set => _idSection = value;
        }

        private int _idElement { get; set; }
        public int IdElement
        {
            get => _idElement;
            set => _idElement = value;
        }

        private string _icon { get; set; }
        
        public string Icon
        {
            get => _icon;
            set => _icon = value;
        }  
        private string _elementName { get; set; }
        
        public string ElementName
        {
            get => _elementName;
            set => _elementName = value;
        }

    }
}
