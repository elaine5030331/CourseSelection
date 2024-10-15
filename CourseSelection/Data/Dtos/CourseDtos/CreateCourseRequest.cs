using CourseSelection.Enums;

namespace CourseSelection.Data.Dtos.CourseDtos
{
    public class CreateCourseRequest
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public bool Required { get; set; }
        public Language Language { get; set; }
        public string Syllabus { get; set; }
        public byte DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int MaximumEnrollment { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
    }
}