using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonDailyReport.Server.Logics.Contract.BoldReport;
using OrisonDailyReport.Shared.Entities.BoldReport;
using System.Net.Mime;

namespace OrisonDailyReport.Server.Controllers.BoldReport
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoldReportController : ControllerBase
    {
        private readonly IBoldReportManager _repository;

        public BoldReportController(IBoldReportManager boldReportManager)
        {
            _repository = boldReportManager;
        }
        [HttpPost]
        [Route("GetReport")]
        public async Task<IActionResult> GetReport(DataSource Value,string key)
        {
            var fileStreamResult = await _repository.GetReport(Value, key);
            return File(fileStreamResult.FileStream, MediaTypeNames.Application.Pdf, $"{Value.ReportName}.pdf");
        }
        //[HttpGet]
        //public async Task<string> Get()
        //{
        //    return "hello";
        //}
    }
}
