using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.Models
{
    public class Addition: UTExLMSContext
    {
        public virtual DbSet<ElementSection> ElementSections { get; set; } 
        public virtual DbSet<OverviewCourse> OverviewCourses { get; set; }
        public Addition() { }
        public Addition(DbContextOptions<UTExLMSContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Gọi base để đảm bảo cấu hình mặc định được giữ lại

            // Cấu hình OverviewCourse
            modelBuilder.Entity<OverviewCourse>()
                .HasKey(oc => new { oc.IdPerson, oc.IdCourse });
            modelBuilder.Entity<ElementSection>()
                .HasKey(oc => new { oc.IdElement });
            
        }
    }
}
