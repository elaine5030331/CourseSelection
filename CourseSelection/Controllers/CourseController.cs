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
        /// <param name="request">課程資料</param>
        /// <returns> 課程ID </returns>
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
        ///        "dayOfWeek": 1(課程為每週幾，星期一 = 0，星期二 = 1，星期三 = 2..., 星期日 = 6),
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
        /// 3. 開課人數最少須10人，最多120人
        /// 4. 請輸入上課教室
        /// 5. 請輸入授課講師
        /// 6. 新增課程失敗
        /// </response>
        /// <response code ="401">未通過身分驗證</response>
        /// <response code ="403">權限不足</response>
        [HttpPost("CreateCourse")]
        [ProducesResponseType(typeof(CreateCourseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCourse(CreateCourseRequest request)
        {
            var result = await _courseService.CreateCourseAsync(request);
            if (result.IsSuccess)
                return Ok(result.ResultDto);
            return BadRequest(result.ErrorMessage);
        }

        /// <summary>
        /// 取得課程列表(需包含講師基本資料)
        /// </summary>
        /// <returns></returns>
        /// <response code ="200">取得課程列表成功</response>
        /// <response code ="404">找不到任何課程內容</response>
        [HttpGet("GetCourseList")]
        [ProducesResponseType(typeof(GetCourseListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCourseList()
        {
            var result = await _courseService.GetCourseListAsync();
            if (result == null)
                return StatusCode(404);
            return Ok(result);
        }

        /// <summary>
        /// 取得授課講師所開課程列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code ="200">取得授課講師所開課程列表成功</response>
        /// <response code ="404">找不到任何該講師對應的課程內容</response>
        [HttpGet("GetCourseListByTeacherId/{id}")]
        [ProducesResponseType(typeof(GetCourseListByTeacherIdResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCourseListByTeacherId(int id)
        {
            var result = await _courseService.GetCourseListByTeacherIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// 更新課程內容
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>課程ID</returns>
        /// <remarks>
        /// Sample request:<br/>
        /// 
        ///     PUT
        ///     {
        ///        "id": 1,
        ///        "courseId": "PS100A", 
        ///        "name": "普通心理學", 
        ///        "credits": 3,
        ///        "required": true(必修為 true，選修為 false),
        ///        "language": 1 (國語 = 0, 英語 = 1)
        ///        "syllabus": "本課程涵蓋心理學的基礎知識，每週設定教學主題，教授心理學知識及其生活應用。",
        ///        "dayOfWeek": 1(課程為每週幾，星期一 = 0，星期二 = 1，星期三 = 2..., 星期日 = 6),
        ///        "startTime": "09:00:00",
        ///        "endTime": "12:00:00",
        ///        "maximumEnrollment": 85,
        ///        "isDelete": false,
        ///        "classId": 1,
        ///        "teacherId": 1
        ///     }
        /// </remarks>
        /// <response code ="200">新增課程成功</response>
        /// <response code ="400">
        /// 1. 參數異常
        /// 2. 請輸入課程編號
        /// 3. 請輸入課程名稱
        /// 4. 請輸入開課人數上限
        /// 5. 請輸入上課教室
        /// 6. 請輸入授課講師
        /// 7. 找不到此課程
        /// 8. 更新課程內容失敗
        /// </response>
        /// <response code ="401">未通過身分驗證</response>
        /// <response code ="403">權限不足</response>
        [HttpPut("UpdateCourse/{id}")]
        [ProducesResponseType(typeof(UpdateCourseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCourse(int id, UpdateCourseRequest request)
        {
            if (id != request.Id)
                return BadRequest("參數異常");
            var result = await _courseService.UpdateCourseAsync(request);
            if(result.IsSuccess)
                return Ok(result.ResultDto);
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
        /// <response code ="401">未通過身分驗證</response>
        /// <response code ="403">權限不足</response>
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
