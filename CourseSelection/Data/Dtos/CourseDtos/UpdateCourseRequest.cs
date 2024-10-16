using CourseSelection.Common.Enums;

namespace CourseSelection.Data.Dtos.CourseDtos
{
    public class UpdateCourseRequest
    {
        public int Id { get; set; }
        public string CourseId { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public bool Required { get; set; }
        public Language Language { get; set; }
        public string Syllabus { get; set; }
        public DayOfWeekEnum DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int MaximumEnrollment { get; set; }
        public bool IsDelete { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
    }
}