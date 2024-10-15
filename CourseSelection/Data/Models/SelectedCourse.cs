using System;
using System.Collections.Generic;

namespace CourseSelection.Data.Models;

public partial class SelectedCourse
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CoursesId { get; set; }

    public byte? Status { get; set; }

    public DateTime? SelectedAt { get; set; }

    public virtual Course Courses { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
