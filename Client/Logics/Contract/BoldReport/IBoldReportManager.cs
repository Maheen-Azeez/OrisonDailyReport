using OrisonDailyReport.Shared.Entities.BoldReport;

namespace OrisonDailyReport.Client.Logics.Contract.BoldReport
{
    public interface IBoldReportManager
    {
        public Task<MemoryStream> GetReport(DataSource Value);
    }
}
