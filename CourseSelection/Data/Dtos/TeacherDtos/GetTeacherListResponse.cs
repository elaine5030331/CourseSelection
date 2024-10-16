namespace CourseSelection.Data.Dtos.TeacherDtos
{
    public class GetTeacherListResponse
    {
        public List<TeacherInfo> TeacherInfos { get; set; }
    }

    public class TeacherInfo
    {
        public int UserId { get; set; }
        public string TeacherName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public int PositionId { get; set; }
    }
}