using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonDailyReport.Server.Logics.Contract.Main;
using OrisonDailyReport.Shared.Entities.Registers;

namespace OrisonDailyReport.Server.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsMainController : ControllerBase
    {
        private IAccountsMain _repository;

        public AccountsMainController(IAccountsMain repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("Collections")]
        public async Task<ActionResult<IEnumerable<dtAccountsMain>>> GetGridData(int BranchId, string AccYear, DateTime SDate, DateTime EDate, string Description, string Criteria, string key)
        {
            var UserData = await _repository.GetCollections(BranchId, AccYear, SDate, EDate, Description, Criteria, key);
            return UserData;
        }
        [HttpGet]
        [Route("GetUserwiseCollectionSummary")]
        public async Task<ActionResult<IEnumerable<dtAccountsMain>>> GetUserwiseCollectionSummary(int BranchId, string AccYear, DateTime SDate, DateTime EDate, string? Description, string Criteria, string? userName, string key)
        {
            var UserData = await _repository.GetUserwiseCollectionSummary(BranchId, AccYear, SDate, EDate, Description, Criteria, userName, key);
            return Ok(UserData);
        }
        [HttpGet]
        [Route("GetFeeType")]
        public async Task<ActionResult<IEnumerable<string>>> GetFeeType(string AcademicYear, int BranchID, string key)
        {
            return await _repository.GetFeeType(AcademicYear, BranchID, key);
        }
        [HttpGet]
        [Route("OnlineCollection")]
        public async Task<ActionResult<IEnumerable<dtOnlineCollection>>> GetOnlineCollection(string AcademicYear, int BranchID, DateTime fromdate, DateTime todate, string key)
        {
            var UserData = await _repository.GetOnlineCollection(AcademicYear, BranchID, fromdate, todate, key);
            return Ok(UserData);
        }
        [HttpGet]
        [Route("DynamicFeewiseCollection")]
        public async Task<ActionResult<IEnumerable<object>>> GetDynamicFeewiseCollection(string AcademicYear, int BranchID, DateTime fromdate, DateTime todate, string key)
        {
            var UserData = await _repository.GetDynamicFeewiseCollection(AcademicYear, BranchID, fromdate, todate, key);
            return Ok(UserData);
        }
        [HttpGet]
        [Route("FeewiseCollection")]
        public async Task<ActionResult<IEnumerable<dtFeeWiseCollection>>> GetFeewiseCollection(string AcademicYear, int BranchID, DateTime fromdate, DateTime todate, string key)
        {
            var UserData = await _repository.GetFeewiseCollection(AcademicYear, BranchID, fromdate, todate, key);
            return Ok(UserData);
        }
        [HttpGet]
        [Route("SchoolwiseCollection")]
        public async Task<ActionResult<IEnumerable<SchoolCollectionDTO>>> GetSchoolwiseCollection(string AcademicYear, int BranchID, DateTime fromdate, DateTime todate, string key)
        {
            var UserData = await _repository.GetSchoolwiseCollection(AcademicYear, BranchID, fromdate, todate, key);
            return Ok(UserData);
        }
        [HttpGet]
        [Route("ItemStockSale")]
        public async Task<ActionResult<IEnumerable<DtItemStock>>> GetItemStockSale(string AcademicYear, int BranchID, DateTime fromdate, DateTime todate,string basicType, string key)
        {
            var itemStocks = await _repository.GetItemStockSale(AcademicYear, BranchID, fromdate, todate,basicType, key);
            return Ok(itemStocks);
        }
    }
}
