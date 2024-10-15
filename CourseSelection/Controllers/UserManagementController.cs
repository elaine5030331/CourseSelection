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
        ///        department: 1 (心理學系 = 1, 特殊教育學系 = 2, 資訊管理學系 = 3, 資訊工程學系 = 4, 建築學系 = 5, 會計學系 = 6, 國際經營與貿易學系 =7)
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
        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest request)
        {
            var result = await _userManagementService.CreateStudent(request);
            if (result.IsSuccess)
                return Ok();
            return BadRequest(result.ErrorMessage);
        }
    }
}
