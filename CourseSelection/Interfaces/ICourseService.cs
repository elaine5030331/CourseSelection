using CourseSelection.Data;
using CourseSelection.Data.Dtos.CourseDtos;

namespace CourseSelection.Interfaces
{
    public interface ICourseService
    {
        Task<OperationResult<CreateCourseResponse>> CreateCourseAsync(CreateCourseRequest request);
        Task<GetCourseListResponse> GetCourseListAsync();
        Task<OperationResult<UpdateCourseResponse>> UpdateCourseAsync(UpdateCourseRequest request);
        Task<OperationResult> DeleteCourseAsync(int id);
    }
}
