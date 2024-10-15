using CourseSelection.Data.Dtos.CourseDtos;
using CourseSelection.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSelection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// 新增課程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:<br/>
        /// 
        ///     POST
        ///     {
        ///        "courseId": "PS100A", 
        ///        "name": "普通心理學", 
        ///        "credits": 3,
        ///        "required": true(必修為 true，選修為 false),
        ///        "language": 1 (國語 = 0, 英語 = 1)
        ///        "syllabus": "本課程旨在介紹現代心理學的各種基礎知識，引導學生取得心理學重要學理與其個人日常生活之間的連結，並對心理學的理論與應用有一個概括的認識",
        ///        "dayOfWeek": 1,
        ///        "startTime": "09:00:00",
        ///        "endTime": "12:00:00",
        ///        "maximumEnrollment": 85,
        ///        "classId": 1,
        ///        "teacherId": 1
        ///        
        ///     }
        /// </remarks>
        /// <response code ="200">新增課程成功</response>
        /// <response code ="400">
        /// 1. 請輸入課程編號
        /// 2. 請輸入課程名稱
        /// 3. 請輸入開課人數上限
        /// 4. 新增課程失敗
        /// </response>
        /// <response code ="401">未通過身分驗證</response>
        /// <response code ="403">權限不足</response>
        [HttpPost("CreateCourse")]
        public async Task<IActionResult> CreateCourse(CreateCourseRequest request)
        {
            var result = await _courseService.CreateCourseAsync(request);
            if (result.IsSuccess)
                return Ok();
            return BadRequest(result.ErrorMessage);
        }

        /// <summary>
        /// 刪除課程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code ="204">刪除課程成功</response>
        /// <response code ="400">
        /// 1. 找不到對應的課程
        /// 2. 刪除課程失敗
        /// </response>
        [HttpDelete("DeleteCourse/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeleteCourseAsync(id);
            if (result.IsSuccess)
                return NoContent();
            return BadRequest(result.ErrorMessage);
        }
    }
}
