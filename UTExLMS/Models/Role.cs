using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Role
    {
        public Role()
        {
            People = new HashSet<Person>();
        }

        public int IdRole { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
