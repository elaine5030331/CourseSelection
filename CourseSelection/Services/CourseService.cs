using CourseSelection.Data;
using CourseSelection.Data.Dtos.CourseDtos;
using CourseSelection.Data.Models;
using CourseSelection.Interfaces;

namespace CourseSelection.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepo;
        private readonly ILogger<CourseService> _logger;
        private readonly int academicYear = DateTime.UtcNow.Year - 1911;

        public CourseService(IRepository<Course> courseRepo, ILogger<CourseService> logger)
        {
            _courseRepo = courseRepo;
            _logger = logger;
        }

        public async Task<OperationResult> CreateCourseAsync(CreateCourseRequest request)
        {
            if (string.IsNullOrEmpty(request.CourseId))
                return new OperationResult("請輸入課程編號");
            if (string.IsNullOrEmpty(request.Name))
                return new OperationResult("請輸入課程名稱");
            if (request.MaximumEnrollment <= 0)
                return new OperationResult("請輸入開課人數上限");

            try
            {
                var course = new Course()
                {
                    CourseId = request.CourseId,
                    Name = request.Name,
                    Credits = request.Credits,
                    Required = request.Required,
                    Language = request.Language,
                    Syllabus = request.Syllabus,
                    AcademicYear = (short)academicYear,
                    DayOfWeek = request.DayOfWeek,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    MaximumEnrollment = request.MaximumEnrollment,
                    ClassId = request.ClassId,
                    TeacherId = request.TeacherId
                };

                await _courseRepo.AddAsync(course);
                return new OperationResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new OperationResult()
                {
                    IsSuccess = false,
                    ErrorMessage = "新增課程失敗"
                };
            }
        }

        public async Task<OperationResult> DeleteCourseAsync(int id)
        {
            try
            {
                var course = await _courseRepo.GetByIdAsync(id);
                if (course == null || course.IsDelete)
                    return new OperationResult("找不到對應的課程");

                course.IsDelete = true;
                await _courseRepo.UpdateAsync(course);
                return new OperationResult();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, ex.Message);
                return new OperationResult()
                {
                    IsSuccess = false,
                    ErrorMessage = "刪除課程失敗"
                };
            }
        }

        public Task<OperationResult> GetCourseListAsync(GetCourseListRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<UpdateCourseResponse>> UpdateCourseAsync(UpdateCourseRequest request)
        {
            if (string.IsNullOrEmpty(request.CourseId))
                return new OperationResult<UpdateCourseResponse>("請輸入課程編號");
            if (string.IsNullOrEmpty(request.Name))
                return new OperationResult<UpdateCourseResponse>("請輸入課程名稱");
            if (request.MaximumEnrollment <= 0)
                return new OperationResult<UpdateCourseResponse>("請輸入開課人數上限");
            if (request.ClassId <= 0)
                return new OperationResult<UpdateCourseResponse>("請輸入上課教室");
            if (request.TeacherId <= 0)
                return new OperationResult<UpdateCourseResponse>("請輸入授課講師");

            try
            {
                var course = await _courseRepo.GetByIdAsync(request.Id);
                if (course == null)
                    return new OperationResult<UpdateCourseResponse>("找不到此課程");

                course.CourseId = request.CourseId;
                course.Name = request.Name;
                course.Credits = request.Credits;
                course.Required = request.Required;
                course.Language = request.Language;
                course.Syllabus = request.Syllabus;
                course.DayOfWeek = request.DayOfWeek;
                course.StartTime = request.StartTime;
                course.EndTime = request.EndTime;
                course.MaximumEnrollment = request.MaximumEnrollment;
                course.IsDelete = request.IsDelete;
                course.ClassId = request.ClassId;
                course.TeacherId = request.TeacherId;

                await _courseRepo.UpdateAsync(course);
                var result = new UpdateCourseResponse { Id =  course.Id };
                return new OperationResult<UpdateCourseResponse>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new OperationResult<UpdateCourseResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "更新課程內容失敗"
                };
            }
        }
    }
}
