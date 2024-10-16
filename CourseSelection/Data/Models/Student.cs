using CourseSelection.Common.Enums;
using System;
using System.Collections.Generic;

namespace CourseSelection.Data.Models;

public partial class Student
{
    public int Id { get; set; }

    public int UserId { get; set; }

    /// <summary>
    /// 學號
    /// </summary>
    public string StudentId { get; set; }

    /// <summary>
    /// 入學年份
    /// </summary>
    public int EnrollmentYear { get; set; }

    /// <summary>
    /// 所屬系所(心理學系 = 1, 特殊教育學系 = 2, 資訊管理學系 = 3, 資訊工程學系 = 4, 建築學系 = 5, 會計學系 = 6, 國際經營與貿易學系 =7
    /// </summary>
    public StudentDepartments Department { get; set; }

    public virtual ICollection<SelectedCourse> SelectedCourses { get; set; } = new List<SelectedCourse>();

    public virtual User User { get; set; }
}
