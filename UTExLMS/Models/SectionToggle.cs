﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public class SectionToggle
    {
        public Section HeaderSections { get; set; }    
        public ObservableCollection<ElementSection> ElementSections { get; set; }  
    }
}