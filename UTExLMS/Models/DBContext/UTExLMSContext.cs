using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UTExLMS.Models.DBContext
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
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
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
        public virtual DbSet<VwStudentCourse> VwStudentCourses { get; set; } = null!;
        public virtual DbSet<VwStudentTest> VwStudentTests { get; set; } = null!;

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
                entity.HasKey(e => e.IdAssign)
                    .HasName("PK__Assignme__64CD3ADFBAE86707");

                entity.ToTable("Assignment");

                entity.Property(e => e.IdAssign)
                    .ValueGeneratedNever()
                    .HasColumnName("idAssign");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

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

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Assignmen__idLec__5AEE82B9");

                entity.HasOne(d => d.IdSectionNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.IdSection)
                    .HasConstraintName("FK__Assignmen__idSec__59FA5E80");
            });

            modelBuilder.Entity<AssignmentStudent>(entity =>
            {
                entity.HasKey(e => new { e.IdAssign, e.IdStudent })
                    .HasName("PK__Assignme__D796255761A8DFFA");

                entity.ToTable("Assignment_Student");

                entity.Property(e => e.IdAssign).HasColumnName("idAssign");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.Property(e => e.NumAttempts).HasColumnName("numAttempts");

                entity.Property(e => e.TotalScore).HasColumnName("totalScore");

                entity.Property(e => e.TotalTimeSpent).HasColumnName("totalTimeSpent");

                entity.HasOne(d => d.IdAssignNavigation)
                    .WithMany(p => p.AssignmentStudents)
                    .HasForeignKey(d => d.IdAssign)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__idAss__5DCAEF64");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.AssignmentStudents)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__idStu__5EBF139D");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClass)
                    .HasName("PK__Class__17317A5AF926CA7F");

                entity.ToTable("Class");

                entity.Property(e => e.IdClass)
                    .ValueGeneratedNever()
                    .HasColumnName("idClass");

                entity.Property(e => e.IdLecturer).HasColumnName("idLecturer");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.Property(e => e.IdSubject).HasColumnName("idSubject");

                entity.Property(e => e.NameClass)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameClass");

                entity.Property(e => e.Progress).HasColumnName("progress");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Class__idLecture__44FF419A");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK__Class__idStudent__4316F928");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("FK__Class__idSubject__440B1D61");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdCmt)
                    .HasName("PK__Comment__398F2EDC3064042F");

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
                    .HasConstraintName("FK__Comment__idDiscu__693CA210");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Comment__idLectu__6B24EA82");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK__Comment__idStude__6A30C649");
            });

            modelBuilder.Entity<Discussion>(entity =>
            {
                entity.HasKey(e => e.IdDiscuss)
                    .HasName("PK__Discussi__99B6A08BFB4EFD18");

                entity.ToTable("Discussion");

                entity.Property(e => e.IdDiscuss)
                    .ValueGeneratedNever()
                    .HasColumnName("idDiscuss");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IdLecturer).HasColumnName("idLecturer");

                entity.Property(e => e.IdSection).HasColumnName("idSection");

                entity.Property(e => e.NameDiscuss)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameDiscuss");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Discussions)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Discussio__idLec__66603565");

                entity.HasOne(d => d.IdSectionNavigation)
                    .WithMany(p => p.Discussions)
                    .HasForeignKey(d => d.IdSection)
                    .HasConstraintName("FK__Discussio__idSec__656C112C");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.HasKey(e => e.IdLecturer)
                    .HasName("PK__Lecturer__5BC7EC9E13AB3562");

                entity.ToTable("Lecturer");

                entity.HasIndex(e => e.Email, "UC_LecturerEmail")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNum, "UC_LecturerPhone")
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

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phoneNum");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Lecturers)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__Lecturer__idRole__3B75D760");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PK__Material__6AC7E3EB607A2A0E");

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

                entity.Property(e => e.TypeMaterial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("typeMaterial");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Material__idLect__4CA06362");

                entity.HasOne(d => d.IdSectionNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.IdSection)
                    .HasConstraintName("FK__Material__idSect__4BAC3F29");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.IdQues)
                    .HasName("PK__Question__D037C50030CF5D18");

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
                    .HasConstraintName("FK__Question__idTest__534D60F1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Role__E5045C54BB5C6435");

                entity.ToTable("Role");

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
                    .HasName("PK__Section__53793649D15AFBED");

                entity.ToTable("Section");

                entity.Property(e => e.IdSection)
                    .ValueGeneratedNever()
                    .HasColumnName("idSection");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IdClass).HasColumnName("idClass");

                entity.Property(e => e.IdLecturer).HasColumnName("idLecturer");

                entity.Property(e => e.NameSection)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameSection");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.IdClass)
                    .HasConstraintName("FK__Section__idClass__47DBAE45");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Section__idLectu__48CFD27E");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(e => e.IdSemester)
                    .HasName("PK__Semester__C6BE1497EE9B232E");

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
                    .HasName("PK__Student__35B1F88AD1F9D625");

                entity.ToTable("Student");

                entity.HasIndex(e => e.Email, "UC_StudentEmail")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNum, "UC_StudentPhone")
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

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phoneNum");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__Student__idRole__38996AB5");
            });

            modelBuilder.Entity<StudentAn>(entity =>
            {
                entity.HasKey(e => e.IdAns)
                    .HasName("PK__StudentA__3E0F126ED335DD69");

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
                    .HasConstraintName("FK__StudentAn__idQue__571DF1D5");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.StudentAns)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK__StudentAn__idStu__5629CD9C");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.IdSubject)
                    .HasName("PK__Subject__A324CF9EA59AD1F5");

                entity.ToTable("Subject");

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
                    .HasConstraintName("FK__Subject__idSemes__403A8C7D");
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.HasKey(e => e.IdSubmiss)
                    .HasName("PK__Submissi__423E86D575A930D6");

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
                    .HasConstraintName("FK__Submissio__idAss__619B8048");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK__Submissio__idStu__628FA481");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(e => e.IdTest)
                    .HasName("PK__Test__BCD9141A55C85A0C");

                entity.ToTable("Test");

                entity.Property(e => e.IdTest)
                    .ValueGeneratedNever()
                    .HasColumnName("idTest");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

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

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TimeLimit).HasColumnName("timeLimit");

                entity.HasOne(d => d.IdLecturerNavigation)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.IdLecturer)
                    .HasConstraintName("FK__Test__idLecturer__5070F446");

                entity.HasOne(d => d.IdSectionNavigation)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.IdSection)
                    .HasConstraintName("FK__Test__idSection__4F7CD00D");
            });

            modelBuilder.Entity<VwStudentCourse>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_StudentCourses");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.NameClass)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameClass");

                entity.Property(e => e.Progress).HasColumnName("progress");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");
            });

            modelBuilder.Entity<VwStudentTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_StudentTests");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.IdStudent).HasColumnName("idStudent");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.NameTest)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameTest");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
