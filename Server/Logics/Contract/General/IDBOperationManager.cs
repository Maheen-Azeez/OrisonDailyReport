using OrisonDailyReport.Shared.Entities.General;
using OrisonDailyReport.Shared.Entities.Registers;

namespace OrisonDailyReport.Server.Logics.Contract.General
{
    public interface IDBOperationManager
    {
        public Task<string> GetURL(string Source, string key);
        Task<List<DtAcademicYear>> GetAcademicYear(int BranchID, string key);
        Task<List<dtAccountsMain>> GetUserName(string key);
        Task<string> GetCurrentAcademicYear(int BranchID, string key);
    }
}
