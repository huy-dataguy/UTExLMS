using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UTExLMS.Models
{
    public partial class UTExLMSContext : DbContext
    {
        public UTExLMSContext()
        {
        }

        public UTExLMSContext(DbContextOptions<UTExLMSContext> options)
            : base(options)
        {
        }
        public virtual DbSet<OverviewCourse> OverviewCourses { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<AssignmentStudent> AssignmentStudents { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseStudent> CourseStudents { get; set; } = null!;
        public virtual DbSet<Discussion> Discussions { get; set; } = null!;
        public virtual DbSet<Lecturer> Lecturers { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentAn> StudentAns { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Submission> Submissions { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=UTExLMS;Integrated Security=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<OverviewCourse>()
            .HasKey(oc => new
            {
                oc.IdStudent,
                oc.IdCourse
            });
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => e.IdAssign)
                    .HasName("PK__Assignme__64CD3ADF92CB3B0F");

                entity.ToTable("Assignment");

                entity.Property(e => e.IdAssign)
                    .ValueGeneratedNever()
                    .HasColumnName("idAssign");

                entity.Property(e => e.Descript)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descript");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.IdLecturer).HasColumnName("idLecturer");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.NameAssign)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameAssign");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.Property(e => e.Statu)
                    .HasColumnName("statu")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Assignmen__idLec__628FA481");

                entity.HasOne(d => d.IdSectionNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.IdSection)
                    .HasConstraintName("FK__Assignmen__idSec__619B8048");
            });

            modelBuilder.Entity<AssignmentStudent>(entity =>
            {
                entity.HasKey(e => new { e.IdAssign, e.IdStudent })
                    .HasName("PK__Assignme__D79625573B79197D");

                entity.ToTable("AssignmentStudent");

                entity.Property(e => e.IdAssign).HasColumnName("idAssign");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.Property(e => e.NumAttempts).HasColumnName("numAttempts");

                entity.Property(e => e.TotalScore).HasColumnName("totalScore");

                entity.Property(e => e.TotalTimeSpent).HasColumnName("totalTimeSpent");

                entity.HasOne(d => d.IdAssignNavigation)
                    .WithMany(p => p.AssignmentStudents)
                    .HasForeignKey(d => d.IdAssign)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__idAss__656C112C");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.AssignmentStudents)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__idStu__66603565");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdCmt)
                    .HasName("PK__Comment__398F2EDCAEF8FB9A");

                entity.ToTable("Comment");

                entity.Property(e => e.IdCmt)
                    .ValueGeneratedNever()
                    .HasColumnName("idCmt");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.IdDiscuss).HasColumnName("idDiscuss");

                entity.Property(e => e.IdLecturer).HasColumnName("idLecturer");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.HasOne(d => d.IdDiscussNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdDiscuss)
                    .HasConstraintName("FK__Comment__idDiscu__70DDC3D8");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Comment__idLectu__72C60C4A");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK__Comment__idStude__71D1E811");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCourse)
                    .HasName("PK__Course__8982E309153535FB");

                entity.ToTable("Course");

                entity.Property(e => e.IdCourse)
                    .ValueGeneratedNever()
                    .HasColumnName("idCourse");

                entity.Property(e => e.IdLecturer).HasColumnName("idLecturer");

                entity.Property(e => e.IdSubject).HasColumnName("idSubject");

                entity.Property(e => e.ImgCourse)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("imgCourse");

                entity.Property(e => e.NameCourse)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameCourse");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Course__idLectur__49C3F6B7");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("FK__Course__idSubjec__48CFD27E");
            });

            modelBuilder.Entity<CourseStudent>(entity =>
            {
                entity.HasKey(e => new { e.IdStudent, e.IdCourse })
                    .HasName("PK__CourseSt__BD29D6BA4385FD15");

                entity.ToTable("CourseStudent");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.Progress).HasColumnName("progress");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.CourseStudents)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseStu__idCou__76969D2E");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.CourseStudents)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseStu__idStu__75A278F5");
            });

            modelBuilder.Entity<Discussion>(entity =>
            {
                entity.HasKey(e => e.IdDiscuss)
                    .HasName("PK__Discussi__99B6A08BB3288443");

                entity.ToTable("Discussion");

                entity.Property(e => e.IdDiscuss)
                    .ValueGeneratedNever()
                    .HasColumnName("idDiscuss");

                entity.Property(e => e.Descript)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descript");

                entity.Property(e => e.IdLecturer).HasColumnName("idLecturer");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.NameDiscuss)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameDiscuss");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Discussions)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Discussio__idLec__6E01572D");

                entity.HasOne(d => d.IdSectionNavigation)
                    .WithMany(p => p.Discussions)
                    .HasForeignKey(d => d.IdSection)
                    .HasConstraintName("FK__Discussio__idSec__6D0D32F4");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.HasKey(e => e.IdLecturer)
                    .HasName("PK__Lecturer__5BC7EC9EE34B99D7");

                entity.ToTable("Lecturer");

                entity.HasIndex(e => e.Email, "UQ__Lecturer__AB6E616489C30380")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNum, "UQ__Lecturer__F62ADD6497DB0B87")
                    .IsUnique();

                entity.Property(e => e.IdLecturer)
                    .ValueGeneratedNever()
                    .HasColumnName("idLecturer");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Pass)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phoneNum");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Lecturers)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__Lecturer__idRole__403A8C7D");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PK__Material__6AC7E3EBEB4F9183");

                entity.ToTable("Material");

                entity.Property(e => e.IdMaterial)
                    .ValueGeneratedNever()
                    .HasColumnName("idMaterial");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("filePath");

                entity.Property(e => e.IdLecturer).HasColumnName("idLecturer");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.NameMaterial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameMaterial");

                entity.Property(e => e.Statu)
                    .HasColumnName("statu")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TypeMaterial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("typeMaterial");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Material__idLect__52593CB8");

                entity.HasOne(d => d.IdSectionNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.IdSection)
                    .HasConstraintName("FK__Material__idSect__5165187F");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.IdQues)
                    .HasName("PK__Question__D037C5001B9C4A2E");

                entity.ToTable("Question");

                entity.Property(e => e.IdQues)
                    .ValueGeneratedNever()
                    .HasColumnName("idQues");

                entity.Property(e => e.A)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.B)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.C)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.D)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdTest).HasColumnName("idTest");

                entity.Property(e => e.NameQues)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nameQues");

                entity.Property(e => e.TrueAns)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("trueAns");

                entity.HasOne(d => d.IdTestNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.IdTest)
                    .HasConstraintName("FK__Question__idTest__59FA5E80");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Roles__E5045C542F0480A5");

                entity.Property(e => e.IdRole)
                    .ValueGeneratedNever()
                    .HasColumnName("idRole");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameRole");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => e.IdSection)
                    .HasName("PK__Section__5379364964C8D54C");

                entity.ToTable("Section");

                entity.Property(e => e.IdSection)
                    .ValueGeneratedNever()
                    .HasColumnName("idSection");

                entity.Property(e => e.Descript)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descript");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdLecturer).HasColumnName("idLecturer");

                entity.Property(e => e.NameSection)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameSection");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.IdCourse)
                    .HasConstraintName("FK__Section__idCours__4CA06362");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Section__idLectu__4D94879B");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(e => e.IdSemester)
                    .HasName("PK__Semester__C6BE1497BA3640D2");

                entity.ToTable("Semester");

                entity.Property(e => e.IdSemester)
                    .ValueGeneratedNever()
                    .HasColumnName("idSemester");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.NameSemester)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameSemester");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdStudent)
                    .HasName("PK__Student__35B1F88A480F4D72");

                entity.ToTable("Student");

                entity.HasIndex(e => e.Email, "UQ__Student__AB6E6164F2BC3415")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNum, "UQ__Student__F62ADD64085A6730")
                    .IsUnique();

                entity.Property(e => e.IdStudent)
                    .ValueGeneratedNever()
                    .HasColumnName("idStudent");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Pass)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phoneNum");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__Student__idRole__3A81B327");
            });

            modelBuilder.Entity<StudentAn>(entity =>
            {
                entity.HasKey(e => e.IdAns)
                    .HasName("PK__StudentA__3E0F126ED82E474F");

                entity.Property(e => e.IdAns)
                    .ValueGeneratedNever()
                    .HasColumnName("idAns");

                entity.Property(e => e.IdQues).HasColumnName("idQues");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.Property(e => e.StudentAns)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("studentAns");

                entity.HasOne(d => d.IdQuesNavigation)
                    .WithMany(p => p.StudentAns)
                    .HasForeignKey(d => d.IdQues)
                    .HasConstraintName("FK__StudentAn__idQue__5DCAEF64");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.StudentAns)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK__StudentAn__idStu__5CD6CB2B");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.IdSubject)
                    .HasName("PK__Subjects__A324CF9EC1273E19");

                entity.Property(e => e.IdSubject)
                    .ValueGeneratedNever()
                    .HasColumnName("idSubject");

                entity.Property(e => e.IdSemester).HasColumnName("idSemester");

                entity.Property(e => e.NameSubject)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameSubject");

                entity.HasOne(d => d.IdSemesterNavigation)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.IdSemester)
                    .HasConstraintName("FK__Subjects__idSeme__45F365D3");
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.HasKey(e => e.IdSubmiss)
                    .HasName("PK__Submissi__423E86D5E8EF02EB");

                entity.ToTable("Submission");

                entity.Property(e => e.IdSubmiss)
                    .ValueGeneratedNever()
                    .HasColumnName("idSubmiss");

                entity.Property(e => e.DateSubmit)
                    .HasColumnType("date")
                    .HasColumnName("dateSubmit");

                entity.Property(e => e.IdAssign).HasColumnName("idAssign");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.Property(e => e.NameFile)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameFile");

                entity.Property(e => e.PathFile)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pathFile");

                entity.Property(e => e.TypeFile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("typeFile");

                entity.HasOne(d => d.IdAssignNavigation)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.IdAssign)
                    .HasConstraintName("FK__Submissio__idAss__693CA210");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK__Submissio__idStu__6A30C649");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(e => e.IdTest)
                    .HasName("PK__Test__BCD9141A87874E72");

                entity.ToTable("Test");

                entity.Property(e => e.IdTest)
                    .ValueGeneratedNever()
                    .HasColumnName("idTest");

                entity.Property(e => e.Descript)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descript");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.IdLecturer).HasColumnName("idLecturer");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.NameTest)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameTest");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.Property(e => e.Statu)
                    .HasColumnName("statu")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TimeLimit).HasColumnName("timeLimit");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Test__idLecturer__571DF1D5");

                entity.HasOne(d => d.IdSectionNavigation)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.IdSection)
                    .HasConstraintName("FK__Test__idSection__5629CD9C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
