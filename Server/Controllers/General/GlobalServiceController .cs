using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonDailyReport.Server.Logics.Contract.General;
using System.Data;

namespace OrisonDailyReport.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalServiceController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private readonly IDapperManager _dapperManager;
        public GlobalServiceController(IWebHostEnvironment environment, IDapperManager dapperManager)
        {
            _environment = environment;
            this._dapperManager = dapperManager;
        }
        // Dispose method to release resources
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
        [HttpGet]
        [Route("CurrencyMaster")]
        public async Task<ActionResult<string>> GetCurrencyMaster(int BranchID, string key)
        {
            return await Task.FromResult(_dapperManager.Get<string>($"SELECT TOP 1 DecimalFormat FROM Company C INNER JOIN CurrencyMast CM ON CM.Abbreviation=C.Currency WHERE C.ID=" + BranchID, key, null, commandType: CommandType.Text));
        }
    }
}
