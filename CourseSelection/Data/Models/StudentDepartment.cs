﻿using System;
using System.Collections.Generic;

namespace CourseSelection.Data.Models;

public partial class StudentDepartment
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
