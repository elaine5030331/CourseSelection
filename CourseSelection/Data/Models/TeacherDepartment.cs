using System;
using System.Collections.Generic;

namespace CourseSelection.Data.Models;

public partial class TeacherDepartment
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
