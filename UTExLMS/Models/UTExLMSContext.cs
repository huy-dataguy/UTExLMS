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
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseStudent> CourseStudents { get; set; } = null!;
        public virtual DbSet<Discussion> Discussions { get; set; } = null!;
        public virtual DbSet<Element> Elements { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<StudentAn> StudentAns { get; set; } = null!;
        public virtual DbSet<StudentAssignment> StudentAssignments { get; set; } = null!;
        public virtual DbSet<StudentTest> StudentTests { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
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
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => new { e.IdCourse, e.IdSection, e.IdAssign })
                    .HasName("PK__Assignme__D2D1BD57C63623FF");

                entity.ToTable("Assignment");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.IdAssign).HasColumnName("idAssign");

                entity.Property(e => e.Descript)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descript");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.Grade).HasColumnName("grade");

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
                    .HasForeignKey(d => new { d.IdCourse, d.IdSection })
                    .HasConstraintName("FK__Assignment__5CD6CB2B");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdCmt)
                    .HasName("PK__Comment__398F2EDCAC8F77CA");

                entity.ToTable("Comment");

                entity.Property(e => e.IdCmt)
                    .ValueGeneratedNever()
                    .HasColumnName("idCmt");

                entity.Property(e => e.CommentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("commentDate");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdDiscuss).HasColumnName("idDiscuss");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Comment__idPerso__6B24EA82");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => new { d.IdCourse, d.IdSection, d.IdDiscuss })
                    .HasConstraintName("FK__Comment__6A30C649");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCourse)
                    .HasName("PK__Course__8982E309681DBE35");

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
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Course__idLectur__440B1D61");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Course__idSubjec__4316F928");
            });

            modelBuilder.Entity<CourseStudent>(entity =>
            {
                entity.HasKey(e => new { e.IdStudent, e.IdCourse })
                    .HasName("PK__CourseSt__BD29D6BA491205F1");

                entity.ToTable("CourseStudent");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.Progress).HasColumnName("progress");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.CourseStudents)
                    .HasForeignKey(d => d.IdCourse)
                    .HasConstraintName("FK__CourseStu__idCou__6EF57B66");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.CourseStudents)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseStu__idStu__6E01572D");
            });

            modelBuilder.Entity<Discussion>(entity =>
            {
                entity.HasKey(e => new { e.IdCourse, e.IdSection, e.IdDiscuss })
                    .HasName("PK__Discussi__862CC6CD3EDF3193");

                entity.ToTable("Discussion");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.IdDiscuss).HasColumnName("idDiscuss");

                entity.Property(e => e.Descript)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descript");

                entity.Property(e => e.NameDiscuss)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameDiscuss");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Discussions)
                    .HasForeignKey(d => new { d.IdCourse, d.IdSection })
                    .HasConstraintName("FK__Discussion__6754599E");
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.HasKey(e => new { e.IdElement, e.IdCourse, e.IdSection })
                    .HasName("PK__Element__98154505104BA67B");

                entity.ToTable("Element");

                entity.Property(e => e.IdElement).HasColumnName("idElement");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.TypeElement)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("typeElement");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Elements)
                    .HasForeignKey(d => new { d.IdCourse, d.IdSection })
                    .HasConstraintName("FK__Element__49C3F6B7");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => new { e.IdMaterial, e.IdCourse, e.IdSection })
                    .HasName("PK__Material__AA0CB4EDAEC150D1");

                entity.ToTable("Material");

                entity.Property(e => e.IdMaterial).HasColumnName("idMaterial");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("filePath");

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
                    .WithOne(p => p.Material)
                    .HasForeignKey<Material>(d => new { d.IdMaterial, d.IdCourse, d.IdSection })
                    .HasConstraintName("FK__Material__4D94879B");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PK__Person__BAB33700B2BDEA8D");

                entity.ToTable("Person");

                entity.HasIndex(e => e.Email, "UQ__Person__AB6E616468F14678")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNum, "UQ__Person__F62ADD6405FED11D")
                    .IsUnique();

                entity.Property(e => e.IdPerson)
                    .ValueGeneratedNever()
                    .HasColumnName("idPerson");

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
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phoneNum");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Person__idRole__3B75D760");

                entity.HasMany(d => d.IdCourses)
                    .WithMany(p => p.IdLecturers)
                    .UsingEntity<Dictionary<string, object>>(
                        "CourseLecturer",
                        l => l.HasOne<Course>().WithMany().HasForeignKey("IdCourse").HasConstraintName("FK__CourseLec__idCou__76969D2E"),
                        r => r.HasOne<Person>().WithMany().HasForeignKey("IdLecturer").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CourseLec__idLec__75A278F5"),
                        j =>
                        {
                            j.HasKey("IdLecturer", "IdCourse").HasName("PK__CourseLe__D35FC2AEE30C9B72");

                            j.ToTable("CourseLecturer");

                            j.IndexerProperty<int>("IdLecturer").HasColumnName("idLecturer");

                            j.IndexerProperty<int>("IdCourse").HasColumnName("idCourse");
                        });

                entity.HasMany(d => d.Ids)
                    .WithMany(p => p.IdPeople)
                    .UsingEntity<Dictionary<string, object>>(
                        "Studied",
                        l => l.HasOne<Element>().WithMany().HasForeignKey("IdElement", "IdCourse", "IdSection").HasConstraintName("FK__Studied__72C60C4A"),
                        r => r.HasOne<Person>().WithMany().HasForeignKey("IdPerson").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Studied__idPerso__71D1E811"),
                        j =>
                        {
                            j.HasKey("IdPerson", "IdCourse", "IdSection", "IdElement").HasName("PK__Studied__5A5DEDE79B8CC0E7");

                            j.ToTable("Studied");

                            j.IndexerProperty<int>("IdPerson").HasColumnName("idPerson");

                            j.IndexerProperty<int>("IdCourse").HasColumnName("idCourse");

                            j.IndexerProperty<int>("IdSection").HasColumnName("idSection");

                            j.IndexerProperty<int>("IdElement").HasColumnName("idElement");
                        });
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => new { e.IdQues, e.IdTest, e.IdCourse, e.IdSection })
                    .HasName("PK__Question__07F6E1315D153181");

                entity.ToTable("Question");

                entity.Property(e => e.IdQues).HasColumnName("idQues");

                entity.Property(e => e.IdTest).HasColumnName("idTest");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

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

                entity.Property(e => e.NameQues)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nameQues");

                entity.Property(e => e.TrueAns)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("trueAns");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => new { d.IdTest, d.IdCourse, d.IdSection })
                    .HasConstraintName("FK__Question__5441852A");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Roles__E5045C5409B60B36");

                entity.Property(e => e.IdRole)
                    .ValueGeneratedNever()
                    .HasColumnName("idRole");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("roleName");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => new { e.IdCourse, e.IdSection })
                    .HasName("PK__Section__0CB5706D641E45A5");

                entity.ToTable("Section");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

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
                    .HasConstraintName("FK__Section__idCours__46E78A0C");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(e => e.IdSemester)
                    .HasName("PK__Semester__C6BE149774CCBAA8");

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

            modelBuilder.Entity<StudentAn>(entity =>
            {
                entity.HasKey(e => new { e.IdPerson, e.IdCourse, e.IdSection, e.IdTest, e.IdQues })
                    .HasName("PK__StudentA__FEC27DA0FB6EB8C1");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.IdTest).HasColumnName("idTest");

                entity.Property(e => e.IdQues).HasColumnName("idQues");

                entity.Property(e => e.Ans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ans");

                entity.Property(e => e.IsTrue)
                    .HasColumnName("isTrue")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.StudentAns)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentAn__idPer__5812160E");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.StudentAns)
                    .HasForeignKey(d => new { d.IdQues, d.IdTest, d.IdCourse, d.IdSection })
                    .HasConstraintName("FK__StudentAns__59063A47");
            });

            modelBuilder.Entity<StudentAssignment>(entity =>
            {
                entity.HasKey(e => new { e.IdStudent, e.IdCourse, e.IdSection, e.IdAssign })
                    .HasName("PK__StudentA__589CE35F04DB2572");

                entity.ToTable("StudentAssignment");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.IdAssign).HasColumnName("idAssign");

                entity.Property(e => e.DateSubmit)
                    .HasColumnType("date")
                    .HasColumnName("dateSubmit");

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

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.StudentAssignments)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentAs__idStu__6477ECF3");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.StudentAssignments)
                    .HasForeignKey(d => new { d.IdCourse, d.IdSection, d.IdAssign })
                    .HasConstraintName("FK__StudentAssignmen__6383C8BA");
            });

            modelBuilder.Entity<StudentTest>(entity =>
            {
                entity.HasKey(e => new { e.IdStudent, e.IdCourse, e.IdSection, e.IdTest })
                    .HasName("PK__StudentT__B4C1621DBB9810DE");

                entity.ToTable("StudentTest");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.IdTest).HasColumnName("idTest");

                entity.Property(e => e.TotalScore).HasColumnName("totalScore");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.StudentTests)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentTe__idStu__60A75C0F");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.StudentTests)
                    .HasForeignKey(d => new { d.IdTest, d.IdCourse, d.IdSection })
                    .HasConstraintName("FK__StudentTest__5FB337D6");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.IdSubject)
                    .HasName("PK__Subjects__A324CF9ED282F2A1");

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
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Subjects__idSeme__403A8C7D");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(e => new { e.IdTest, e.IdCourse, e.IdSection })
                    .HasName("PK__Test__7C12431C9B50439C");

                entity.ToTable("Test");

                entity.Property(e => e.IdTest).HasColumnName("idTest");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.Descript)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descript");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

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
                    .WithOne(p => p.Test)
                    .HasForeignKey<Test>(d => new { d.IdTest, d.IdCourse, d.IdSection })
                    .HasConstraintName("FK__Test__5165187F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
