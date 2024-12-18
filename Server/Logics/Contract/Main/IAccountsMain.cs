using OrisonDailyReport.Shared.Entities.Registers;

namespace OrisonDailyReport.Server.Logics.Contract.Main
{
    public interface IAccountsMain
    {
        public Task<List<dtAccountsMain>> GetCollections(int BranchId, string AccYear, DateTime SDate, DateTime EDate, string Description, string Criteria, string key);
        public Task<IEnumerable<dtOnlineCollection>> GetOnlineCollection(string AcademicYear, int BranchID, DateTime fromdate, DateTime todate,string key);
        public Task<IEnumerable<dtFeeWiseCollection>> GetFeewiseCollection(string AcademicYear, int BranchID, DateTime fromdate, DateTime todate,string key);
        public Task<IEnumerable<SchoolCollectionDTO>> GetSchoolwiseCollection(string AcademicYear, int BranchID, DateTime fromdate, DateTime todate,string key);
        public Task<IEnumerable<dtAccountsMain>> GetUserwiseCollectionSummary(int BranchId, string AccYear, DateTime SDate, DateTime EDate, string Description, string Criteria, string userName, string key);
        public Task<List<string>> GetFeeType(string academicYear, int branchID, string key);
        Task<IEnumerable<DtItemStock>> GetItemStockSale(string academicYear, int branchID, DateTime fromdate, DateTime todate, string basicType, string key);
        Task<IEnumerable<object>> GetDynamicFeewiseCollection(string academicYear, int branchID, DateTime fromdate, DateTime todate, string key);
    }
}
