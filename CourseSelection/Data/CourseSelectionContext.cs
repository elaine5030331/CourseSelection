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
            entity.HasIndex(e => e.ClassId, "UQ_Classes_ClassId").IsUnique();

            entity.Property(e => e.ClassId)
                .IsRequired()
                .HasMaxLength(256)
                .HasComment("教室代碼");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasComment("教室名稱");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasIndex(e => e.CourseId, "UQ_Courses_CourseId").IsUnique();

            entity.Property(e => e.AcademicYear).HasComment("學年度");
            entity.Property(e => e.CourseId)
                .IsRequired()
                .HasMaxLength(256);
            entity.Property(e => e.CurrentEnrollment).HasComment("目前選課人數");
            entity.Property(e => e.DayOfWeek).HasComment("課程為每週幾，星期一 = 1，星期二 = 2，星期三 = 3..., 星期日 = 7");
            entity.Property(e => e.EndTime).HasComment("上課結束時間");
            entity.Property(e => e.IsDelete).HasComment("已刪除為1，未刪除為0");
            entity.Property(e => e.Language).HasComment("授課語言(國語 = 0, 英語 = 1)");
            entity.Property(e => e.MaximumEnrollment).HasComment("開課人數上限");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(500)
                .HasComment("課程名稱");
            entity.Property(e => e.Required).HasComment("必選修(必修為1，選修為0)");
            entity.Property(e => e.StartTime).HasComment("上課開始時間");
            entity.Property(e => e.Syllabus)
                .IsRequired()
                .HasComment("課程簡介");

            entity.HasOne(d => d.Class).WithMany(p => p.Courses)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Classes");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Teachers");
        });

        modelBuilder.Entity<SelectedCourse>(entity =>
        {
            entity.Property(e => e.Status).HasComment("選課狀態，選課成功 = 0, 已退選 = 1");

            entity.HasOne(d => d.Course).WithMany(p => p.SelectedCourses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SelectedCourses_Courese");

            entity.HasOne(d => d.Student).WithMany(p => p.SelectedCourses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SelectedCourses_Students");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasIndex(e => e.StudentId, "UQ_Students_StudentId").IsUnique();

            entity.HasIndex(e => e.UserId, "UQ_Students_UserId").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Department).HasComment("所屬系所(心理學系 = 1, 特殊教育學系 = 2, 資訊管理學系 = 3, 資訊工程學系 = 4, 建築學系 = 5, 會計學系 = 6, 國際經營與貿易學系 =7");
            entity.Property(e => e.EnrollmentYear).HasComment("入學年份");
            entity.Property(e => e.StudentId)
                .IsRequired()
                .HasMaxLength(500)
                .HasComment("學號");

            entity.HasOne(d => d.User).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Users");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasIndex(e => e.TeacherId, "UQ_Teachers_TeacherId").IsUnique();

            entity.HasIndex(e => e.UserId, "UQ_Teachers_UserId").IsUnique();

            entity.Property(e => e.Department).HasComment("所屬部門(理學院 = 1, 人文與教育學院 = 2, 商學院 = 3, 法學院 = 4, 電資學院 = 5, 工學院 = 6, 設計學院 =7)");
            entity.Property(e => e.Position).HasComment("職稱(助理教授 = 1, 副教授 = 2, 教授 = 3, 講師 = 4)");
            entity.Property(e => e.TeacherId)
                .IsRequired()
                .HasMaxLength(500);

            entity.HasOne(d => d.User).WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teachers_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "UQ_Users_Email").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ_Users_Phone").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(500);
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
