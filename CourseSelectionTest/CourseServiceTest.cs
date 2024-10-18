using Azure.Core;
using CourseSelection.Common.Enums;
using CourseSelection.Data.Dtos.CourseDtos;
using CourseSelection.Data.Dtos.UserManagementDtos;
using CourseSelection.Data.Models;
using CourseSelection.Interfaces;
using CourseSelection.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.Data;

namespace CourseSelectionTest
{
    [TestFixture]
    public class CourseServiceTest
    {
        private CourseService _courseService;
        private Mock<IRepository<Course>> _courseRepository;
        private IDbConnection _connection;
        private ILogger<CourseService> _logger;

        [SetUp]
        public void Setup()
        {
            _courseRepository = new Mock<IRepository<Course>>();
            _courseService = new CourseService(_courseRepository.Object, _logger, _connection);
        }

        [Description("CreateCourse API 開課人數最少須10人，最多120人")]
        [TestCase(9, false)]
        [TestCase(10, true)]
        [TestCase(100, true)]
        [TestCase(121, false)]
        public async Task CreateCourse_WhenMaximumEnrollmentIsInvalid_ReturnError(int nums, bool expected)
        {
            var result = await _courseService.CreateCourseAsync(new CreateCourseRequest
            {
                CourseId = "test100",
                Name = "test",
                Credits = 3,
                Required = true,
                Language = Language.國語,
                Syllabus = "小強！小強你怎麼了小強？小強你不能死啊！",
                DayOfWeek = DayOfWeekEnum.星期一,
                StartTime = default,
                EndTime = default,
                MaximumEnrollment = nums,
                ClassId = 1,
                TeacherId = 1
            });

            Assert.That(result.IsSuccess, Is.EqualTo(expected));
        }

        public static IEnumerable<TestCaseData> DeleteCourseTestCases()
        {
            //資料庫狀態為已刪除，應無法再次操作此API
            yield return new TestCaseData(new Course { Id = 1, IsDelete = true}, false);
            //資料庫狀態尚未被刪除，可以順利刪除此課程I
            yield return new TestCaseData(new Course { Id = 1, IsDelete = false}, true);
        }

        [Description("DeleteCourse API 若課程在資料庫的狀態是IsDelete則回傳結果須為 false")]
        [Test, TestCaseSource(nameof(DeleteCourseTestCases))]
        public async Task DeleteCourse_WhenCantFindCourse_ReturnFalse(Course course, bool expected)
        {
            _courseRepository.Setup(c => c.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(course);
            var result = await _courseService.DeleteCourseAsync(course.Id);

            Assert.That(result.IsSuccess, Is.EqualTo(expected));
        }
    }
}
