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
                    .HasName("PK__Assignme__64CD3ADF316F7880");

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

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

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

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => new { d.IdSection, d.IdCourse })
                    .HasConstraintName("FK__Assignment__236943A5");
            });

            modelBuilder.Entity<AssignmentStudent>(entity =>
            {
                entity.HasKey(e => new { e.IdAssign, e.IdStudent })
                    .HasName("PK__Assignme__D796255794C7C233");

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
                    .HasConstraintName("FK__Assignmen__idAss__2645B050");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.AssignmentStudents)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__idStu__2739D489");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdCmt)
                    .HasName("PK__Comment__398F2EDC091BB5E3");

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
                    .HasConstraintName("FK__Comment__idDiscu__30C33EC3");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Comment__idLectu__32AB8735");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK__Comment__idStude__31B762FC");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCourse)
                    .HasName("PK__Course__8982E30996A7F1AF");

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
                    .HasConstraintName("FK__Course__idLectur__0E6E26BF");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("FK__Course__idSubjec__0D7A0286");
            });

            modelBuilder.Entity<CourseStudent>(entity =>
            {
                entity.HasKey(e => new { e.IdStudent, e.IdCourse })
                    .HasName("PK__CourseSt__BD29D6BA663BC978");

                entity.ToTable("CourseStudent");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.Progress).HasColumnName("progress");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.CourseStudents)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseStu__idCou__367C1819");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.CourseStudents)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseStu__idStu__3587F3E0");
            });

            modelBuilder.Entity<Discussion>(entity =>
            {
                entity.HasKey(e => e.IdDiscuss)
                    .HasName("PK__Discussi__99B6A08B3E5379A7");

                entity.ToTable("Discussion");

                entity.Property(e => e.IdDiscuss)
                    .ValueGeneratedNever()
                    .HasColumnName("idDiscuss");

                entity.Property(e => e.Descript)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descript");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.NameDiscuss)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameDiscuss");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Discussions)
                    .HasForeignKey(d => new { d.IdSection, d.IdCourse })
                    .HasConstraintName("FK__Discussion__2DE6D218");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.HasKey(e => e.IdLecturer)
                    .HasName("PK__Lecturer__5BC7EC9EF9B5FECF");

                entity.ToTable("Lecturer");

                entity.HasIndex(e => e.Email, "UQ__Lecturer__AB6E61647721ADC3")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNum, "UQ__Lecturer__F62ADD64772F8E19")
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
                    .HasConstraintName("FK__Lecturer__idRole__04E4BC85");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PK__Material__6AC7E3EB63A85C04");

                entity.ToTable("Material");

                entity.Property(e => e.IdMaterial)
                    .ValueGeneratedNever()
                    .HasColumnName("idMaterial");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("filePath");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

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

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => new { d.IdSection, d.IdCourse })
                    .HasConstraintName("FK__Material__151B244E");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.IdQues)
                    .HasName("PK__Question__D037C500BA442929");

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
                    .HasConstraintName("FK__Question__idTest__1BC821DD");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Roles__E5045C542C15EFE4");

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
                entity.HasKey(e => new { e.IdSection, e.IdCourse })
                    .HasName("PK__Section__DBE118792CAA989D");

                entity.ToTable("Section");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.Descript)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descript");

                entity.Property(e => e.NameSection)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameSection");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Section__idCours__114A936A");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(e => e.IdSemester)
                    .HasName("PK__Semester__C6BE1497EE2B032D");

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
                    .HasName("PK__Student__35B1F88A2A302A4B");

                entity.ToTable("Student");

                entity.HasIndex(e => e.Email, "UQ__Student__AB6E6164BCF78B2E")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNum, "UQ__Student__F62ADD64EDF10EB6")
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
                    .HasConstraintName("FK__Student__idRole__7F2BE32F");
            });

            modelBuilder.Entity<StudentAn>(entity =>
            {
                entity.HasKey(e => e.IdAns)
                    .HasName("PK__StudentA__3E0F126EDCFACE2C");

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
                    .HasConstraintName("FK__StudentAn__idQue__1F98B2C1");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.StudentAns)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK__StudentAn__idStu__1EA48E88");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.IdSubject)
                    .HasName("PK__Subjects__A324CF9E1556A5DC");

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
                    .HasConstraintName("FK__Subjects__idSeme__0A9D95DB");
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.HasKey(e => e.IdSubmiss)
                    .HasName("PK__Submissi__423E86D5363F75F7");

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
                    .HasConstraintName("FK__Submissio__idAss__2A164134");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK__Submissio__idStu__2B0A656D");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(e => e.IdTest)
                    .HasName("PK__Test__BCD9141A1743D82A");

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

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

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

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => new { d.IdSection, d.IdCourse })
                    .HasConstraintName("FK__Test__18EBB532");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
