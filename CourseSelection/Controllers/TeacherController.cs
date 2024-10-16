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
