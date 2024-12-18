using Microsoft.AspNetCore.Mvc;
using OrisonDailyReport.Shared.Entities.BoldReport;

namespace OrisonDailyReport.Server.Logics.Contract.BoldReport
{
    public interface IBoldReportManager
    {
        Task<FileStreamResult> GetReport(DataSource Data, string key);

    }
}
