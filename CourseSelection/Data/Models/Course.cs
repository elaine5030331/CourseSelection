using System;
using System.Collections.Generic;

namespace CourseSelection.Data.Models;

public partial class Course
{
    public int Id { get; set; }

    public string CourseId { get; set; }

    public string Name { get; set; }

    public int Credits { get; set; }

    public bool Required { get; set; }

    public int Language { get; set; }

    public bool IsDelete { get; set; }

    public string Syllabus { get; set; }

    public short AcademicYear { get; set; }

    public byte DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int MaximumEnrollment { get; set; }

    public int? CurrentEnrollment { get; set; }

    public int TeacherId { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; }

    public virtual ICollection<SelectedCourse> SelectedCourses { get; set; } = new List<SelectedCourse>();

    public virtual Teacher Teacher { get; set; }
}
