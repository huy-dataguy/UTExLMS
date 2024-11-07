using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Element
    {
        public Element()
        {
            IdPeople = new HashSet<Person>();
        }

        public int IdElement { get; set; }
        public int IdCourse { get; set; }
        public int IdSection { get; set; }

        public virtual Section Id { get; set; } = null!;
        public virtual Material Material { get; set; } = null!;
        public virtual Test Test { get; set; } = null!;

        public virtual ICollection<Person> IdPeople { get; set; }
    }
}
