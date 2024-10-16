using CourseSelection.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSelection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        /// <summary>
        /// 取得授課講師列表
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Sample response<br/>
        /// 
        ///     {
        ///         "teacherInfos": [
        ///             {
        ///                 "userId": 1,
        ///                 "teacherName": "Elaine",
        ///                 "email": "elaine5030331@gmail.com",
        ///                 "department": 1(理學院 = 1, 人文與教育學院 = 2, 商學院 = 3, 法學院 = 4, 電資學院 = 5, 工學院 = 6, 設計學院 =7),
        ///                 "position": 0( 助理教授 = 1, 副教授 = 2, 教授 = 3, 講師 = 4)
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <response code ="200">取得授課講師列表成功</response>
        /// <response code ="404">找不到任何講師資料</response>
        [HttpGet("GetTeacherList")]
        public async Task<IActionResult> GetTeacherList()
        {
            var result = await _teacherService.GetTeacherListAsync();
            if (result == null) 
                return NotFound();
            return Ok(result);
        }
    }
}
