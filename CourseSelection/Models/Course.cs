using System;
using System.Collections.Generic;

namespace CourseSelection.Models;

public partial class Course
{
    public int Id { get; set; }

    public string CourseId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Credits { get; set; }

    public bool Required { get; set; }

    public string Language { get; set; } = null!;

    public bool IsDelete { get; set; }

    public string? Syllabus { get; set; }

    public short AcademicYear { get; set; }

    public byte DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int MaximumEnrollment { get; set; }

    public int? CurrentEnrollment { get; set; }

    public int TeacherId { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<SelectedCourse> SelectedCourses { get; set; } = new List<SelectedCourse>();

    public virtual Teacher Teacher { get; set; } = null!;
}
