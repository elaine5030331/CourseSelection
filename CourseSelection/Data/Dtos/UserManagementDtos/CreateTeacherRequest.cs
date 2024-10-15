using CourseSelection.Enums;

namespace CourseSelection.Data.Dtos.UserManagementDtos
{
    public class CreateTeacherRequest : BaseOperationResult
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public TeacherDepartments Department { get; set; }
        public TeacherPosition Position { get; set; }
    }
}