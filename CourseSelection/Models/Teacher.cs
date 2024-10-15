using System;
using System.Collections.Generic;

namespace CourseSelection.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string TeacherId { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Position { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual User User { get; set; } = null!;
}
