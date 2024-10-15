using System;
using System.Collections.Generic;

namespace CourseSelection.Data.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string TeacherId { get; set; }

    /// <summary>
    /// 所屬部門
    /// </summary>
    public int DepartmentId { get; set; }

    public string Position { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual User User { get; set; }
}
