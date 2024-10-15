using CourseSelection.Enums;
using System;
using System.Collections.Generic;

namespace CourseSelection.Data.Models;

public partial class Student
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string StudentId { get; set; }

    public int EnrollmentYear { get; set; }

    public StudentDepartments DepartmentId { get; set; }

    public virtual ICollection<SelectedCourse> SelectedCourses { get; set; } = new List<SelectedCourse>();

    public virtual User User { get; set; }
}
