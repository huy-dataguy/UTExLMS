﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public class OverviewCourse
    {
        public int IdPerson { get; set; }
        public int IdCourse { get; set; }
        public string NameCourse { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Progress { get; set; }
        public string ImgCourse { get; set; }



        public OverviewCourse() { }

        //public virtual DbSet<OverviewClass> OverviewClasses { get; set; }

        //modelBuilder.Entity<OverviewClass>()
        //.HasKey(oc => new {
        //    oc.IdStudent,
        //    oc.IdClass
        //    });

    }



}
