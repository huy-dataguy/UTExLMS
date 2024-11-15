using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public partial class Result
    {
        public string? NameQues { get; set; }
        public string? A { get; set; }
        public string? B { get; set; }
        public string? C { get; set; }
        public string? D { get; set; }
        public string? TrueAns { get; set; }
        public string? Ans { get; set; }

        public Result() { }
    }
}
