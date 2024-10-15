using System;
using System.Collections.Generic;

namespace CourseSelection.Models;

public partial class Class
{
    public int Id { get; set; }

    public string ClassId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
