using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public class OverviewClass
    {
        public int IdStudent { get; set; }
        public int IdClass { get; set; }
        public string NameClass { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Progress { get; set; }
        public string ImgClass { get; set; }



        public OverviewClass() { }

        //public virtual DbSet<OverviewClass> OverviewClasses { get; set; }

        //modelBuilder.Entity<OverviewClass>()
        //.HasKey(oc => new {
        //    oc.IdStudent,
        //    oc.IdClass
        //    });

    }

}
