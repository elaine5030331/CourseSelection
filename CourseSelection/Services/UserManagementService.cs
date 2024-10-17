using CourseSelection.Common.Enums;
using CourseSelection.Data;
using CourseSelection.Data.Dtos.UserManagementDtos;
using CourseSelection.Data.Models;
using CourseSelection.Interfaces;
using System.Text.RegularExpressions;

namespace CourseSelection.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Student> _studentRepo;
        private readonly IRepository<Teacher> _teacherRepo;
        private readonly ILogger<UserManagementService> _logger;

        private const string phonePattern = @"^09\d{8}$";
        private const string emailPattern = @".*@.*\..*";
        private readonly int enrollmentYear = DateTime.UtcNow.Year - 1911;

        public UserManagementService(IRepository<User> userRepo, IRepository<Student> studentRepo, IRepository<Teacher> teacherRepo, ILogger<UserManagementService> logger)
        {
            _userRepo = userRepo;
            _studentRepo = studentRepo;
            _teacherRepo = teacherRepo;
            _logger = logger;
        }

        public async Task<OperationResult<CreateStudentResponse>> CreateStudent(CreateStudentRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return new OperationResult<CreateStudentResponse>("請輸入姓名");
            if (string.IsNullOrEmpty(request.Email))
                return new OperationResult<CreateStudentResponse>("請輸入信箱");
            if (string.IsNullOrEmpty(request.Phone))
                return new OperationResult<CreateStudentResponse>("請輸入電話");

            if ((await _userRepo.AnyAsync(x => x.Email == request.Email)))
                return new OperationResult<CreateStudentResponse>("此信箱已註冊過");
            if ((await _userRepo.AnyAsync(x => x.Phone == request.Phone)))
                return new OperationResult<CreateStudentResponse>("此電話已註冊過");

            if (!Regex.IsMatch(request.Email, emailPattern))
                return new OperationResult<CreateStudentResponse>("信箱格式有誤");
            if (!Regex.IsMatch(request.Phone, phonePattern))
                return new OperationResult<CreateStudentResponse>("電話格式有誤");

            try
            {
                var departmentId = (int)request.Department;

                var students = (await _studentRepo.ListAsync(s => (int)s.Department == departmentId))
                                .OrderBy(s => s.UserId);
                var studentCount = students.Count();
                var studentNo = 1;
                studentNo = (students == null) ? 1 : students.Count() + 1;

                var studentId = $"S{enrollmentYear}{departmentId}{studentNo}";

                if (!Enum.IsDefined(typeof(StudentDepartments), request.Department))
                    return new OperationResult<CreateStudentResponse>("無此系所");

                var user = new User
                {
                    Username = request.Name,
                    Email = request.Email,
                    Phone = request.Phone,
                    Password = request.Password,
                    CreateAt = DateTime.UtcNow,
                    Student = new Student
                    {
                        StudentId = studentId,
                        EnrollmentYear = enrollmentYear,
                        Department = request.Department
                    }
                };

                await _userRepo.AddAsync(user);

                return new OperationResult<CreateStudentResponse>()
                {
                    IsSuccess = true,
                    ResultDto = new CreateStudentResponse()
                    {
                        Id = user.Student.Id
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new OperationResult<CreateStudentResponse>("新增學生失敗");
            }
        }

        public async Task<OperationResult<CreateTeacherResponse>> CreateTeacher(CreateTeacherRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return new OperationResult<CreateTeacherResponse>("請輸入姓名");
            if (string.IsNullOrEmpty(request.Email))
                return new OperationResult<CreateTeacherResponse>("請輸入信箱");
            if (string.IsNullOrEmpty(request.Phone))
                return new OperationResult<CreateTeacherResponse>("請輸入電話");

            if ((await _userRepo.AnyAsync(x => x.Email == request.Email)))
                return new OperationResult<CreateTeacherResponse>("此信箱已註冊過");
            if ((await _userRepo.AnyAsync(x => x.Phone == request.Phone)))
                return new OperationResult<CreateTeacherResponse>("此電話已註冊過");

            if (!Regex.IsMatch(request.Email, emailPattern))
                return new OperationResult<CreateTeacherResponse>("信箱格式有誤");
            if (!Regex.IsMatch(request.Phone, phonePattern))
                return new OperationResult<CreateTeacherResponse>("電話格式有誤");

            try
            {
                var departmentId = (int)request.Department;
                var teachers = (await _teacherRepo.ListAsync(s => (int)s.Department == departmentId))
                                .OrderBy(s => s.UserId);
                var teacherCount = teachers.Count();
                var teacherNo = 1;
                teacherNo = (teachers == null) ? 1 : teachers.Count() + 1;

                var teacherId = $"T{enrollmentYear}{departmentId}{teacherNo}";

                if (!Enum.IsDefined(typeof(TeacherDepartments), request.Department))
                    return new OperationResult<CreateTeacherResponse>("無此部門");

                if (!Enum.IsDefined(typeof(TeacherPositions), request.Position))
                    return new OperationResult<CreateTeacherResponse>("無此職稱");

                var user = new User
                {
                    Username = request.Name,
                    Email = request.Email,
                    Phone = request.Phone,
                    Password = request.Password,
                    CreateAt = DateTime.UtcNow,
                    Teacher = new Teacher
                    {
                        TeacherId = teacherId,
                        Department = request.Department,
                        Position = request.Position
                    }
                };

                await _userRepo.AddAsync(user);

                return new OperationResult<CreateTeacherResponse>()
                {
                    IsSuccess = true,
                    ResultDto = new CreateTeacherResponse()
                    {
                        Id = user.Teacher.Id
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new OperationResult<CreateTeacherResponse>("新增講師失敗");
            }

        }
    }
}
