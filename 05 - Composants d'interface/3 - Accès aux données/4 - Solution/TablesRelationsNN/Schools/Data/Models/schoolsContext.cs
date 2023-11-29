using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Schools.Data.Models
{
    public partial class schoolsContext : DbContext
    {
        public schoolsContext()
        {
        }

        public schoolsContext(DbContextOptions<schoolsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentsCourse> StudentsCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Name=maConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("courses");

                entity.Property(e => e.CourseId).HasColumnType("int(11)");

                entity.Property(e => e.CourseName).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("grade");

                entity.Property(e => e.GradeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("GradeID");

                entity.Property(e => e.GradeName).HasMaxLength(100);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.HasIndex(e => e.GradeId, "GradeID");

                entity.Property(e => e.StudentId).HasColumnType("int(11)");

                entity.Property(e => e.GradeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("GradeID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student_ibfk_1");
            });

            modelBuilder.Entity<StudentsCourse>(entity =>
            {
                entity.HasKey(e => e.StudentCourseId)
                    .HasName("PRIMARY");

                entity.ToTable("studentscourses");

                entity.HasIndex(e => e.CourseId, "CourseId");

                entity.HasIndex(e => e.StudentId, "StudentId");

                entity.Property(e => e.StudentCourseId).HasColumnType("int(11)");

                entity.Property(e => e.CourseId).HasColumnType("int(11)");

                entity.Property(e => e.StudentId).HasColumnType("int(11)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentsCourses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("studentscourses_ibfk_2");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsCourses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("studentscourses_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
