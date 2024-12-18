using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonDailyReport.Server.Logics.Contract.General;
using OrisonDailyReport.Shared.Entities.General;
using OrisonDailyReport.Shared.Entities.Registers;

namespace OrisonDailyReport.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBOperationController : ControllerBase
    {
        private readonly IDBOperationManager dBOperation;

        public DBOperationController(IDBOperationManager dBOperation)
        {
            this.dBOperation = dBOperation;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtAcademicYear>>> GetAcademicYear(int BranchID, string key)
        {
            return await dBOperation.GetAcademicYear(BranchID, key);
        }

        [HttpGet]
        [Route("GetDate")]
        public ActionResult<DateTime> GetDateTime()
        {
            return DateTime.UtcNow;
        }
        [HttpGet]
        [Route("URL")]
        public async Task<ActionResult<string>> GetURLAsync(string Source, string key)
        {
            return await dBOperation.GetURL(Source, key);
        }
        [HttpGet]
        [Route("CurrentYear")]
        public async Task<ActionResult<string>> GetCurrentAcademicYear(int BranchID, string Key)
        {
            return Ok(await dBOperation.GetCurrentAcademicYear(BranchID, Key));
        }
        [HttpGet]
        [Route("UserName")]
        public async Task<ActionResult<List<dtAccountsMain>>> GetUserName(string Key)
        {
            return Ok(await dBOperation.GetUserName(Key));
        }
    }
}
