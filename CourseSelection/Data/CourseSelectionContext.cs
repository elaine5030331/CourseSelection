using System;
using System.Collections.Generic;
using CourseSelection.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSelection.Data;

public partial class CourseSelectionContext : DbContext
{
    public CourseSelectionContext()
    {
    }

    public CourseSelectionContext(DbContextOptions<CourseSelectionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<SelectedCourse> SelectedCourses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__classes__3213E83F86AA231D");

            entity.ToTable("classes");

            entity.HasIndex(e => e.ClassId, "UQ__classes__7577347F0696B23A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassId)
                .HasMaxLength(256)
                .HasColumnName("classId");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__courses__3213E83FB2C69356");

            entity.ToTable("courses");

            entity.HasIndex(e => e.CourseId, "UQ__courses__2AA84FD08F807AB6").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcademicYear).HasColumnName("academicYear");
            entity.Property(e => e.ClassId).HasColumnName("classId");
            entity.Property(e => e.CourseId)
                .HasMaxLength(256)
                .HasColumnName("courseId");
            entity.Property(e => e.Credits).HasColumnName("credits");
            entity.Property(e => e.CurrentEnrollment)
                .HasDefaultValue(0)
                .HasColumnName("currentEnrollment");
            entity.Property(e => e.DayOfWeek).HasColumnName("dayOfWeek");
            entity.Property(e => e.EndTime).HasColumnName("endTime");
            entity.Property(e => e.IsDelete).HasColumnName("isDelete");
            entity.Property(e => e.Language)
                .HasMaxLength(100)
                .HasColumnName("language");
            entity.Property(e => e.MaximumEnrollment).HasColumnName("maximumEnrollment");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Required).HasColumnName("required");
            entity.Property(e => e.StartTime).HasColumnName("startTime");
            entity.Property(e => e.Syllabus).HasColumnName("syllabus");
            entity.Property(e => e.TeacherId).HasColumnName("teacherId");

            entity.HasOne(d => d.Class).WithMany(p => p.Courses)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_courses_classes");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__courses__teacher__4BAC3F29");
        });

        modelBuilder.Entity<SelectedCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__selected__3213E83FCE6CC156");

            entity.ToTable("selectedCourses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CoursesId).HasColumnName("coursesId");
            entity.Property(e => e.SelectedAt).HasColumnName("selectedAt");
            entity.Property(e => e.StudentId).HasColumnName("studentId");

            entity.HasOne(d => d.Courses).WithMany(p => p.SelectedCourses)
                .HasForeignKey(d => d.CoursesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__selectedC__cours__49C3F6B7");

            entity.HasOne(d => d.Student).WithMany(p => p.SelectedCourses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__selectedC__stude__48CFD27E");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__students__3213E83FA4399641");

            entity.ToTable("students");

            entity.HasIndex(e => e.UserId, "UQ__students__CB9A1CFE2CB55CC4").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.EnrollmentYear).HasColumnName("enrollmentYear");
            entity.Property(e => e.Major)
                .HasMaxLength(256)
                .HasColumnName("major");
            entity.Property(e => e.Minor)
                .HasMaxLength(256)
                .HasColumnName("minor");
            entity.Property(e => e.StudentId).HasColumnName("studentId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__students__userId__46E78A0C");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__teachers__3213E83F8F85CF9D");

            entity.ToTable("teachers");

            entity.HasIndex(e => e.UserId, "UQ__teachers__CB9A1CFE171CCC77").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.Department)
                .HasMaxLength(256)
                .HasColumnName("department");
            entity.Property(e => e.Position)
                .HasMaxLength(256)
                .HasColumnName("position");
            entity.Property(e => e.TeacherId).HasColumnName("teacherId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__teachers__userId__47DBAE45");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FCEAC9358");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasMaxLength(256)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
