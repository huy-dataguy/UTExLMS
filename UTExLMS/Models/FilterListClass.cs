using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public class FilterListClass
    {
        public List<string> SelectedName { get; }
        public FilterListClass()
        {
            this.SelectedName = new List<string>{
                "All",
                "Past",
                "In Progress"
            };
        }
    }
}
