using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonDailyReport.Server.Logics.Contract.General;

namespace OrisonDailyReport.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyManager companyManager;

        public CompanyController(ICompanyManager companyManager)
        {
            this.companyManager = companyManager;
        }
        [HttpGet]
        [Route("getLogo")]
        public async Task<ActionResult<string>> GetLogo(int BranchID, string key)
        {
            return await companyManager.getLogo(BranchID, key);
        }
        [HttpGet]
        [Route("getLogoUrl")]
        public async Task<ActionResult<string>> getLogoUrl(string key)
        {
            return await companyManager.getLogoUrl(key);
        }
        [HttpGet]
        [Route("CompanyCode")]
        public async Task<ActionResult<string>> GetCompanyCode(int branchId, string key)
        {
            return await companyManager.GetCompanyCode(branchId, key);
        }
        [HttpGet]
        [Route("CompanyDetails")]
        public async Task<IEnumerable<object>> GetCompanyDetails(int BranchID, string key)
        {
            try
            {
                return await companyManager.GetCompanyDetails(BranchID, key);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
