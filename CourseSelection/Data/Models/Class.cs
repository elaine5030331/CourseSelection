using System;
using System.Collections.Generic;

namespace CourseSelection.Data.Models;

public partial class Class
{
    public int Id { get; set; }

    /// <summary>
    /// 教室代碼
    /// </summary>
    public string ClassId { get; set; }

    /// <summary>
    /// 教室名稱
    /// </summary>
    public string Name { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
