using CourseSelection.Common.Enums;

namespace CourseSelection.Data.Dtos.CourseDtos
{
    public class GetCourseListByTeacherIdResponse
    {
        public List<CourseInfoById> CourseInfo { get; set; }
        public class CourseInfoById
        {
            public int Id { get; set; }
            public string CourseId { get; set; }
            public string CourseName { get; set; }
            public int Credits { get; set; }
            public bool Required { get; set; }
            public Language Language { get; set; }
            public string Syllabus { get; set; }
            public int AcademicYear { get; set; }
            public byte DayOfWeek { get; set; }
            public TimeSpan StartTime { get; set; }
            public TimeSpan EndTime { get; set; }
            public int MaximumEnrollment { get; set; }
            public int ClassId { get; set; }
            public string ClassName { get; set; }
            public int TeacherId { get; set; }
            public string TeacherName { get; set; }
            public string TeacherEmail { get; set; }
        }
    }
}