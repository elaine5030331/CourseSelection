﻿using Azure.Core;
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
        private Mock<IRepository<Teacher>> _teacherRepository;
        private Mock<IRepository<Class>> _classRepository;
        private IDbConnection _connection;
        private ILogger<CourseService> _logger;

        [SetUp]
        public void Setup()
        {
            _courseRepository = new Mock<IRepository<Course>>();
            _teacherRepository = new Mock<IRepository<Teacher>>();
            _classRepository = new Mock<IRepository<Class>>();
            _courseService = new CourseService(_courseRepository.Object, _logger, _connection, _teacherRepository.Object, _classRepository.Object);
        }

        [Description("CreateCourse API 開課人數最少須10人，最多120人")]
        [TestCase(9, false)]
        [TestCase(10, true)]
        [TestCase(100, true)]
        [TestCase(121, false)]
        public void CreateCourse_WhenMaximumEnrollmentIsInvalid_ReturnError(int nums, bool expected)
        {
            var result = _courseService.IsEnrollmentValid(nums);
            Assert.That(result, Is.EqualTo(expected));
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
