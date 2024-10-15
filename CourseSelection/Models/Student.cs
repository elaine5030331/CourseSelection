using System;
using System.Collections.Generic;

namespace CourseSelection.Models;

public partial class Student
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string StudentId { get; set; } = null!;

    public int EnrollmentYear { get; set; }

    public string Major { get; set; } = null!;

    public string? Minor { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<SelectedCourse> SelectedCourses { get; set; } = new List<SelectedCourse>();

    public virtual User User { get; set; } = null!;
}
