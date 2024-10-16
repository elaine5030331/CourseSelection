using CourseSelection.Common.Enums;
using System;
using System.Collections.Generic;

namespace CourseSelection.Data.Models;

public partial class SelectedCourse
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    /// <summary>
    /// 選課狀態，選課成功 = 0, 已退選 = 1
    /// </summary>
    public SelectedCourseStatus Status { get; set; }

    public DateTime SelectedAt { get; set; }

    public virtual Course Course { get; set; }

    public virtual Student Student { get; set; }
}
