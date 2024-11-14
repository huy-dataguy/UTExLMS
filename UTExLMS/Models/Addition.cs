using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public class Addition: UTExLMSContext
    {
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
                .HasKey(oc => new { oc.IdPerson, oc.IdCourse }); // Đặt khóa chính cho OverviewCourse
            modelBuilder.Entity<OverviewCourse>()
                .HasKey(oc => new { oc.IdPerson, oc.IdCourse }); // Đặt khóa chính cho OverviewCourse

        }
    }
}
