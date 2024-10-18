using CourseSelection.Common.Enums;
using CourseSelection.Data;
using CourseSelection.Data.Dtos.CourseDtos;
using CourseSelection.Data.Dtos.UserManagementDtos;
using CourseSelection.Data.Models;
using CourseSelection.Interfaces;
using Dapper;
using System.Data;
using static CourseSelection.Data.Dtos.CourseDtos.GetCourseListByTeacherIdResponse;

namespace CourseSelection.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepo;
        private readonly IDbConnection _connection;
        private readonly ILogger<CourseService> _logger;
        private readonly int academicYear = DateTime.UtcNow.Year - 1911;

        public CourseService(IRepository<Course> courseRepo, ILogger<CourseService> logger, IDbConnection connection)
        {
            _courseRepo = courseRepo;
            _logger = logger;
            _connection = connection;
        }

        public async Task<OperationResult<CreateCourseResponse>> CreateCourseAsync(CreateCourseRequest request)
        {
            if (string.IsNullOrEmpty(request.CourseId))
                return new OperationResult<CreateCourseResponse>("請輸入課程編號");
            if (string.IsNullOrEmpty(request.Name))
                return new OperationResult<CreateCourseResponse>("請輸入課程名稱");
            if (request.MaximumEnrollment < 10 || request.MaximumEnrollment > 120)
                return new OperationResult<CreateCourseResponse>("開課人數最少須10人，最多120人");
            if (request.ClassId <= 0)
                return new OperationResult<CreateCourseResponse>("請輸入上課教室");
            if (request.TeacherId <= 0)
                return new OperationResult<CreateCourseResponse>("請輸入授課講師");

            try
            {
                if (!Enum.IsDefined(typeof(Language), request.Language))
                    return new OperationResult<CreateCourseResponse>("無此語言");

                if (!Enum.IsDefined(typeof(DayOfWeekEnum), request.DayOfWeek))
                    return new OperationResult<CreateCourseResponse>("一星期只有七天ㄋㄟ");

                if (!await _classRepo.AnyAsync(c => c.Id == request.ClassId))
                    return new OperationResult<CreateCourseResponse>("目前沒有這堂課");

                if (!await _teacherRepo.AnyAsync(t => t.Id == request.TeacherId))
                    return new OperationResult<CreateCourseResponse>("目前沒有這位講師");

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
                var result = new CreateCourseResponse { Id = course.Id };
                return new OperationResult<CreateCourseResponse>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new OperationResult<CreateCourseResponse>()
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

        public async Task<GetCourseListResponse> GetCourseListAsync()
        {
            var sql = @"
                        SELECT 
	                        courses.id AS Id,
	                        courseId AS CourseId,
	                        courses.[name] AS CourseName,
	                        credits AS Credits,
	                        [required] AS Required,
	                        [language] AS Language,
	                        syllabus AS Syllabus,
	                        academicYear AS AcademicYear,
	                        [dayOfWeek] AS DayOfWeek,
	                        startTime AS StartTime,
	                        endTime AS EndTime,
	                        maximumEnrollment AS MaximumEnrollment,
                            classes.id AS ClassId,
	                        classes.[name] AS ClassName,
	                        teachers.id AS TeacherId,
	                        users.username AS TeacherName,
	                        users.email AS TeacherEmail
                        FROM dbo.courses
                        JOIN classes ON classes.id = courses.classId
                        JOIN teachers ON teachers.id = courses.teacherId
                        JOIN users ON users.id = teachers.userId
                        WHERE IsDelete = 0";

            var queryResult = (await _connection.QueryAsync<CourseItem>(sql)).ToList();
            var result = new GetCourseListResponse() { CourseInfo = queryResult };

            return result;

        }

        public async Task<GetCourseListByTeacherIdResponse> GetCourseListByTeacherIdAsync(int id)
        {
            var parameter = new {TeacherId = id};
            var sql = @"
                        SELECT 
	                        courses.id AS Id,
	                        courseId AS CourseId,
	                        courses.[name] AS CourseName,
	                        credits AS Credits,
	                        [required] AS Required,
	                        [language] AS Language,
	                        syllabus AS Syllabus,
	                        academicYear AS AcademicYear,
	                        [dayOfWeek] AS DayOfWeek,
	                        startTime AS StartTime,
	                        endTime AS EndTime,
	                        maximumEnrollment AS MaximumEnrollment,
                            classes.id AS ClassId,
	                        classes.[name] AS ClassName,
	                        teachers.id AS TeacherId,
	                        users.username AS TeacherName,
	                        users.email AS TeacherEmail
                        FROM dbo.courses
                        JOIN classes ON classes.id = courses.classId
                        JOIN teachers ON teachers.id = courses.teacherId
                        JOIN users ON users.id = teachers.userId
                        WHERE teachers.id = @TeacherId
                        AND IsDelete = 0";

            var queryString = (await _connection.QueryAsync<CourseInfoById>(sql, parameter)).ToList();
            var result = new GetCourseListByTeacherIdResponse()
            {
                CourseInfo = queryString
            };
            return result;
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

                if (!Enum.IsDefined(typeof(Language), request.Language))
                    return new OperationResult<UpdateCourseResponse>("無此語言");

                if (!Enum.IsDefined(typeof(DayOfWeekEnum), request.DayOfWeek))
                    return new OperationResult<UpdateCourseResponse>("一星期只有七天ㄋㄟ");

                if (!await _classRepo.AnyAsync(c => c.Id == request.ClassId))
                    return new OperationResult<UpdateCourseResponse>("目前沒有這堂課");

                if (!await _teacherRepo.AnyAsync(t => t.Id == request.TeacherId))
                    return new OperationResult<UpdateCourseResponse>("目前沒有這位講師");

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
