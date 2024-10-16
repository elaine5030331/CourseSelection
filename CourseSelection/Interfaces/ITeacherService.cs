using CourseSelection.Data.Dtos.TeacherDtos;

namespace CourseSelection.Interfaces
{
    public interface ITeacherService
    {
        Task<GetTeacherListResponse> GetTeacherListAsync();
    }
}
