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

        public async Task<OperationResult> CreateStudent(CreateStudentRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return new OperationResult("請輸入姓名");
            if (string.IsNullOrEmpty(request.Email))
                return new OperationResult("請輸入信箱");
            if (string.IsNullOrEmpty(request.Phone))
                return new OperationResult("請輸入電話");

            if ((await _userRepo.AnyAsync(x => x.Email == request.Email)))
                return new OperationResult("此信箱已註冊過");
            if ((await _userRepo.AnyAsync(x => x.Phone == request.Phone)))
                return new OperationResult("此電話已註冊過");

            if (!Regex.IsMatch(request.Email, emailPattern))
                return new OperationResult("信箱格式有誤");
            if (!Regex.IsMatch(request.Phone, phonePattern))
                return new OperationResult("電話格式有誤");

            try
            {
                var departmentId = (int)request.Department;

                var students = (await _studentRepo.ListAsync(s => (int)s.DepartmentId == departmentId))
                                .OrderBy(s => s.UserId);
                var studentCount = students.Count();
                var studentNo = 1;
                studentNo = (students == null) ? 1 : students.Count() + 1;

                //var enrollmentYear = DateTime.Now.Year - 1911;
                var studentId = $"S{enrollmentYear}{departmentId}{studentNo}";

                var user = new User
                {
                    Username = request.Name,
                    Email = request.Email,
                    Phone = request.Phone,
                    Password = request.Password,
                    CreatedAt = DateTime.UtcNow,
                    Student = new Student
                    {
                        StudentId = studentId,
                        EnrollmentYear = enrollmentYear,
                        DepartmentId = request.Department
                    }
                };

                await _userRepo.AddAsync(user);

                return new OperationResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new OperationResult("新增學生失敗");
            }
        }

        public async Task<OperationResult> CreateTeacher(CreateTeacherRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return new OperationResult("請輸入姓名");
            if (string.IsNullOrEmpty(request.Email))
                return new OperationResult("請輸入信箱");
            if (string.IsNullOrEmpty(request.Phone))
                return new OperationResult("請輸入電話");

            if ((await _userRepo.AnyAsync(x => x.Email == request.Email)))
                return new OperationResult("此信箱已註冊過");
            if ((await _userRepo.AnyAsync(x => x.Phone == request.Phone)))
                return new OperationResult("此電話已註冊過");

            if (!Regex.IsMatch(request.Email, emailPattern))
                return new OperationResult("信箱格式有誤");
            if (!Regex.IsMatch(request.Phone, phonePattern))
                return new OperationResult("電話格式有誤");

            try
            {
                var departmentId = (int)request.Department;
                var teachers = (await _teacherRepo.ListAsync(s => (int)s.DepartmentId == departmentId))
                                .OrderBy(s => s.UserId);
                var teacherCount = teachers.Count();
                var teacherNo = 1;
                teacherNo = (teachers == null) ? 1 : teachers.Count() + 1;

                var teacherId = $"T{enrollmentYear}{departmentId}{teacherNo}";

                var user = new User
                {
                    Username = request.Name,
                    Email = request.Email,
                    Phone = request.Phone,
                    Password = request.Password,
                    CreatedAt = DateTime.UtcNow,
                    Teacher = new Teacher
                    {
                        TeacherId = teacherId,
                        DepartmentId = request.Department,
                        Position = request.Position
                    }
                };

                await _userRepo.AddAsync(user);

                return new OperationResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new OperationResult("新增講師失敗");
            }

        }
    }
}
