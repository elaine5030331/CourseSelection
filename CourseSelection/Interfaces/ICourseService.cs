using CourseSelection.Data;
using CourseSelection.Data.Dtos.CourseDtos;

namespace CourseSelection.Interfaces
{
    public interface ICourseService
    {
        Task<OperationResult<CreateCourseResponse>> CreateCourseAsync(CreateCourseRequest request);
        Task<OperationResult> GetCourseListAsync(GetCourseListRequest request);
        Task<OperationResult<UpdateCourseResponse>> UpdateCourseAsync(UpdateCourseRequest request);
        Task<OperationResult> DeleteCourseAsync(int id);
    }
}
