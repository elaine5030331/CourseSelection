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
                var academicYear = DateTime.UtcNow.Year - 1911;

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

        public Task<OperationResult> DeleteCourseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetCourseListAsync(GetCourseListRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> UpdateCourseAsync(UpdateCourseRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
