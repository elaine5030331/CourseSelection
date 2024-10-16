using CourseSelection.Common.Enums;
using System;
using System.Collections.Generic;

namespace CourseSelection.Data.Models;

public partial class Course
{
    public int Id { get; set; }

    public string CourseId { get; set; }

    /// <summary>
    /// 課程名稱
    /// </summary>
    public string Name { get; set; }

    public int Credits { get; set; }

    /// <summary>
    /// 必選修(必修為1，選修為0)
    /// </summary>
    public bool Required { get; set; }

    /// <summary>
    /// 授課語言(國語 = 0, 英語 = 1)
    /// </summary>
    public Language Language { get; set; }

    /// <summary>
    /// 課程簡介
    /// </summary>
    public string Syllabus { get; set; }

    /// <summary>
    /// 學年度
    /// </summary>
    public short AcademicYear { get; set; }

    /// <summary>
    /// 課程為每週幾，星期一 = 0，星期二 = 1，星期三 = 2..., 星期日 = 6
    /// </summary>
    public DayOfWeekEnum DayOfWeek { get; set; }

    /// <summary>
    /// 上課開始時間
    /// </summary>
    public TimeOnly StartTime { get; set; }

    /// <summary>
    /// 上課結束時間
    /// </summary>
    public TimeOnly EndTime { get; set; }

    /// <summary>
    /// 開課人數上限
    /// </summary>
    public int MaximumEnrollment { get; set; }

    /// <summary>
    /// 目前選課人數
    /// </summary>
    public int CurrentEnrollment { get; set; }

    /// <summary>
    /// 已刪除為1，未刪除為0
    /// </summary>
    public bool IsDelete { get; set; }

    public int TeacherId { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; }

    public virtual ICollection<SelectedCourse> SelectedCourses { get; set; } = new List<SelectedCourse>();

    public virtual Teacher Teacher { get; set; }
}
