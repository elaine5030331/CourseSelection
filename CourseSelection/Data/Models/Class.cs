﻿using System;
using System.Collections.Generic;

namespace CourseSelection.Data.Models;

public partial class Class
{
    public int Id { get; set; }

    public string ClassId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
