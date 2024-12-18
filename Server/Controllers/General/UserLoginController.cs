using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonDailyReport.Server.Logics.Contract.General;
using OrisonDailyReport.Shared.Entities.Login;

namespace OrisonDailyReport.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private IUserLoginManager _repository;

        public UserLoginController(IUserLoginManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoLoginModel>>> GetUserData(int UserID, int BranchID, string key)
        {
            var UserData = await _repository.GetUserData(UserID, BranchID, key);

            if (UserData == null)
            {
                return NotFound();
            }

            return UserData;
        }
    }
}
