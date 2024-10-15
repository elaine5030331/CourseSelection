﻿// <auto-generated />
using System;
using CourseSelection.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseSelection.Data.Migrations
{
    [DbContext(typeof(CourseSelectionContext))]
    partial class CourseSelectionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseSelection.Data.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassId")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("classId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__classes__3213E83F86AA231D");

                    b.HasIndex(new[] { "ClassId" }, "UQ__classes__7577347F0696B23A")
                        .IsUnique();

                    b.ToTable("classes", (string)null);
                });

            modelBuilder.Entity("CourseSelection.Data.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short>("AcademicYear")
                        .HasColumnType("smallint")
                        .HasColumnName("academicYear");

                    b.Property<int>("ClassId")
                        .HasColumnType("int")
                        .HasColumnName("classId");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("courseId");

                    b.Property<int>("Credits")
                        .HasColumnType("int")
                        .HasColumnName("credits");

                    b.Property<int?>("CurrentEnrollment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("currentEnrollment");

                    b.Property<byte>("DayOfWeek")
                        .HasColumnType("tinyint")
                        .HasColumnName("dayOfWeek");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time")
                        .HasColumnName("endTime");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("isDelete");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("language");

                    b.Property<int>("MaximumEnrollment")
                        .HasColumnType("int")
                        .HasColumnName("maximumEnrollment");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<bool>("Required")
                        .HasColumnType("bit")
                        .HasColumnName("required");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time")
                        .HasColumnName("startTime");

                    b.Property<string>("Syllabus")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("syllabus");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("teacherId");

                    b.HasKey("Id")
                        .HasName("PK__courses__3213E83FB2C69356");

                    b.HasIndex("ClassId");

                    b.HasIndex("TeacherId");

                    b.HasIndex(new[] { "CourseId" }, "UQ__courses__2AA84FD08F807AB6")
                        .IsUnique();

                    b.ToTable("courses", (string)null);
                });

            modelBuilder.Entity("CourseSelection.Data.Models.SelectedCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CoursesId")
                        .HasColumnType("int")
                        .HasColumnName("coursesId");

                    b.Property<DateTime?>("SelectedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("selectedAt");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("studentId");

                    b.HasKey("Id")
                        .HasName("PK__selected__3213E83FCE6CC156");

                    b.HasIndex("CoursesId");

                    b.HasIndex("StudentId");

                    b.ToTable("selectedCourses", (string)null);
                });

            modelBuilder.Entity("CourseSelection.Data.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("EnrollmentYear")
                        .HasColumnType("int")
                        .HasColumnName("enrollmentYear");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("studentId");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userId");

                    b.HasKey("Id")
                        .HasName("PK__students__3213E83FA4399641");

                    b.HasIndex("DepartmentId");

                    b.HasIndex(new[] { "UserId" }, "UQ__students__CB9A1CFE2CB55CC4")
                        .IsUnique();

                    b.ToTable("students", (string)null);
                });

            modelBuilder.Entity("CourseSelection.Data.Models.StudentDepartment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("StudentDepartments");
                });

            modelBuilder.Entity("CourseSelection.Data.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("departmentId")
                        .HasComment("所屬部門");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("position");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("teacherId");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userId");

                    b.HasKey("Id")
                        .HasName("PK__teachers__3213E83F8F85CF9D");

                    b.HasIndex("DepartmentId");

                    b.HasIndex(new[] { "UserId" }, "UQ__teachers__CB9A1CFE171CCC77")
                        .IsUnique();

                    b.ToTable("teachers", (string)null);
                });

            modelBuilder.Entity("CourseSelection.Data.Models.TeacherDepartment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TeacherDepartments");
                });

            modelBuilder.Entity("CourseSelection.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("phone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("PK__users__3213E83FCEAC9358");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("CourseSelection.Data.Models.Course", b =>
                {
                    b.HasOne("CourseSelection.Data.Models.Class", "Class")
                        .WithMany("Courses")
                        .HasForeignKey("ClassId")
                        .IsRequired()
                        .HasConstraintName("FK_courses_classes");

                    b.HasOne("CourseSelection.Data.Models.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .IsRequired()
                        .HasConstraintName("FK__courses__teacher__4BAC3F29");

                    b.Navigation("Class");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("CourseSelection.Data.Models.SelectedCourse", b =>
                {
                    b.HasOne("CourseSelection.Data.Models.Course", "Courses")
                        .WithMany("SelectedCourses")
                        .HasForeignKey("CoursesId")
                        .IsRequired()
                        .HasConstraintName("FK__selectedC__cours__49C3F6B7");

                    b.HasOne("CourseSelection.Data.Models.Student", "Student")
                        .WithMany("SelectedCourses")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK__selectedC__stude__48CFD27E");

                    b.Navigation("Courses");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("CourseSelection.Data.Models.Student", b =>
                {
                    b.HasOne("CourseSelection.Data.Models.StudentDepartment", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .IsRequired()
                        .HasConstraintName("FK_students_StudentDepartments");

                    b.HasOne("CourseSelection.Data.Models.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("CourseSelection.Data.Models.Student", "UserId")
                        .IsRequired()
                        .HasConstraintName("FK__students__userId__46E78A0C");

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseSelection.Data.Models.Teacher", b =>
                {
                    b.HasOne("CourseSelection.Data.Models.TeacherDepartment", "Department")
                        .WithMany("Teachers")
                        .HasForeignKey("DepartmentId")
                        .IsRequired()
                        .HasConstraintName("FK_teachers_TeacherDepartments");

                    b.HasOne("CourseSelection.Data.Models.User", "User")
                        .WithOne("Teacher")
                        .HasForeignKey("CourseSelection.Data.Models.Teacher", "UserId")
                        .IsRequired()
                        .HasConstraintName("FK__teachers__userId__47DBAE45");

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseSelection.Data.Models.Class", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("CourseSelection.Data.Models.Course", b =>
                {
                    b.Navigation("SelectedCourses");
                });

            modelBuilder.Entity("CourseSelection.Data.Models.Student", b =>
                {
                    b.Navigation("SelectedCourses");
                });

            modelBuilder.Entity("CourseSelection.Data.Models.StudentDepartment", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("CourseSelection.Data.Models.Teacher", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("CourseSelection.Data.Models.TeacherDepartment", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("CourseSelection.Data.Models.User", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
