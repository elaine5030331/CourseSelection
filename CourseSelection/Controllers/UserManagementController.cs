using CourseSelection.Data.Dtos.UserManagementDtos;
using CourseSelection.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSelection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        /// <summary>
        /// 新增學生
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:<br/>
        /// 
        ///     POST
        ///     {
        ///        "name": "康怡萱", 
        ///        "password": "Aa*1234", 
        ///        "email": "test@gmail.com", (格式：需包還 "@" 及 "." 字元)
        ///        "phone": "0960123321", (格式：需為09開頭，並且電話號碼長度為10)
        ///        "department": 1 (心理學系 = 1, 特殊教育學系 = 2, 資訊管理學系 = 3, 資訊工程學系 = 4, 建築學系 = 5, 會計學系 = 6, 國際經營與貿易學系 =7)
        ///     }
        /// </remarks>
        /// <response code ="200">新增學生成功</response>
        /// <response code ="400">
        /// 1. 請輸入姓名
        /// 2. 請輸入信箱
        /// 3. 請輸入電話
        /// 4. 此信箱已註冊過
        /// 5. 此電話已註冊過
        /// 6. 信箱格式有誤
        /// 7. 電話格式有誤
        /// 8. 新增學生失敗
        /// </response>
        /// <response code ="401">未通過身分驗證</response>
        /// <response code ="403">權限不足</response>
        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest request)
        {
            var result = await _userManagementService.CreateStudent(request);
            if (result.IsSuccess)
                return Ok();
            return BadRequest(result.ErrorMessage);
        }

        /// <summary>
        /// 新增講師
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:<br/>
        /// 
        ///     POST
        ///     {
        ///        "name": "Elaine", 
        ///        "password": "Aa*1234", 
        ///        "email": "elaine@gmail.com", (格式：需包還 "@" 及 "." 字元)
        ///        "phone": "0960121433", (格式：需為09開頭，並且電話號碼長度為10)
        ///        "department": 1 (理學院 = 1, 人文與教育學院 = 2, 商學院 = 3, 法學院 = 4, 電資學院 = 5, 工學院 = 6, 設計學院 =7)
        ///        "position": 1( 助理教授 = 1, 副教授 = 2, 教授 = 3, 講師 = 4)
        ///     }
        /// </remarks>
        /// <response code ="200">新增講師成功</response>
        /// <response code ="400">
        /// 1. 請輸入姓名
        /// 2. 請輸入信箱
        /// 3. 請輸入電話
        /// 4. 此信箱已註冊過
        /// 5. 此電話已註冊過
        /// 6. 信箱格式有誤
        /// 7. 電話格式有誤
        /// 8. 新增講師失敗
        /// </response>
        /// <response code ="401">未通過身分驗證</response>
        /// <response code ="403">權限不足</response>
        [HttpPost("CreateTeacher")]
        public async Task<IActionResult> CreateTeacher(CreateTeacherRequest request)
        {
            var result = await _userManagementService.CreateTeacher(request);
            if(result.IsSuccess)
                return Ok();
            return BadRequest(result.ErrorMessage);
        }
    }
}
