using Azure.Core;
using CourseSelection.Common.Enums;
using CourseSelection.Data;
using CourseSelection.Data.Dtos.UserManagementDtos;
using CourseSelection.Data.Models;
using CourseSelection.Interfaces;
using CourseSelection.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text.RegularExpressions;

namespace CourseSelectionTest
{
    [TestFixture]
    public class UserManagementServiceTest
    {
        private UserManagementService _userManagementService;
        private Mock<IRepository<User>> _userRepository;
        private Mock<IRepository<Student>> _studentRepository;
        private Mock<IRepository<Teacher>> _teacherRepository;
        private ILogger<UserManagementService> _logger;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IRepository<User>>();
            _studentRepository = new Mock<IRepository<Student>>();
            _teacherRepository = new Mock<IRepository<Teacher>>();
            _userManagementService = new UserManagementService(_userRepository.Object, _studentRepository.Object, _teacherRepository.Object, _logger);
        }

        public static IEnumerable<TestCaseData> CreateTeacherTestCases()
        {
            yield return new TestCaseData(string.Empty, "1234567890", "test@example.com", "請輸入姓名");
            yield return new TestCaseData("test", string.Empty, "test@example.com", "請輸入電話");
            yield return new TestCaseData("test", "1234567890", string.Empty, "請輸入信箱");
            yield return new TestCaseData("test", "09123", "test@example.com", "電話格式有誤");
            yield return new TestCaseData("test", "12345", "test@example.com", "電話格式有誤");
            yield return new TestCaseData("test", "12345", "testexample.com", "信箱格式有誤");
            yield return new TestCaseData("test", "12345", "test@examplecom", "信箱格式有誤");
            yield return new TestCaseData("test", "12345", "testexamplecom", "信箱格式有誤");

        }

        [Description("檢測傳入 CreateTeacher API 的欄位是否符合格式")]
        [Test, TestCaseSource(nameof(CreateTeacherTestCases))]
        public async Task CreateTeacher_WhenValueIsInvalid_ReturnError(string name, string phone, string email, string expectedMessage)
        {
            var request = new CreateTeacherRequest { Name = name, Phone = phone, Email = email };

            var result = await _userManagementService.CreateTeacher(new CreateTeacherRequest
            {
                Name = name,
                Phone = phone,
                Email = email,
                Password = "test",
                Department = TeacherDepartments.理學院,
                Position = TeacherPositions.教授
            });

            Assert.That(result.ErrorMessage, Is.EqualTo(expectedMessage));
        }
    }
}