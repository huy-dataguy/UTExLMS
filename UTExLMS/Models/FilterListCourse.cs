using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public class FilterListCourse
    {
        public List<string> SelectedName { get; }
        public FilterListCourse()
        {
            this.SelectedName = new List<string>{
                "All",
                "Past",
                "In Progress"
            };
        }
    }
}
