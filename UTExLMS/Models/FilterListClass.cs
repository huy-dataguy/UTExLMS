using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public class FilterListClass
    {
        public List<string> Name { get; }
        public FilterListClass()
        {
            this.Name = new List<string>{
                "All",
                "Past",
                "In progress"
            };
        }
    }
}
