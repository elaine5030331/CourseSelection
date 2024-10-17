using CourseSelection.Data;
using CourseSelection.Data.Dtos.UserManagementDtos;

namespace CourseSelection.Interfaces
{
    public interface IUserManagementService
    {
        Task<OperationResult<CreateTeacherResponse>> CreateTeacher(CreateTeacherRequest request);
        Task<OperationResult> CreateStudent(CreateStudentRequest request);
    }
}
