using CourseSelection.Common.Enums;
using System;
using System.Collections.Generic;

namespace CourseSelection.Data.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string TeacherId { get; set; }

    /// <summary>
    /// 所屬部門(理學院 = 1, 人文與教育學院 = 2, 商學院 = 3, 法學院 = 4, 電資學院 = 5, 工學院 = 6, 設計學院 =7)
    /// </summary>
    public TeacherDepartments Department { get; set; }

    /// <summary>
    /// 職稱(助理教授 = 1, 副教授 = 2, 教授 = 3, 講師 = 4)
    /// </summary>
    public TeacherPositions Position { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual User User { get; set; }
}
