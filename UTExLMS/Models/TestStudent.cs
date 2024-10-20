using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public class TestStudent {
     
        public int ID { get; set; }
        public string Name { get; set; }
        public string Crush { get; set; }
        public TestStudent(int iD, string name, string crush)
        {
            ID = iD;
            Name = name;
            Crush = crush;
        }

    }
}
