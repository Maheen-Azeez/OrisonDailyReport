using OrisonDailyReport.Shared.Entities.Registers;
using System.Dynamic;

namespace OrisonDailyReport.Client.Logics.Contract.Registers
{
    public interface IAccountsMain
    {
        public Task<IEnumerable<dtAccountsMain>> GetCollections(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria);
        public Task<IEnumerable<dtOnlineCollection>> GetOnlineCollection(string AcademicYear, int BranchID, string fromdate, string todate);
        public Task<List<ExpandoObject>> GetDynamicFeewiseCollection(string AcademicYear, int BranchID, string fromdate, string todate);
        public Task<IEnumerable<dtFeeWiseCollection>> GetFeewiseCollection(string AcademicYear, int BranchID, string fromdate, string todate);
        public Task<IEnumerable<SchoolCollectionDTO>> GetSchoolwiseCollection(string AcademicYear, int BranchID, string fromdate, string todate);
        public Task<IEnumerable<DtItemStock>> GetItemStockSale(string AcademicYear, int BranchID, string fromdate, string todate,string basicType);
        public Task<IEnumerable<dtAccountsMain>> GetUserwiseCollectionSummary(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria, string userName);
        public Task<IEnumerable<string>> GetFeeType(string AcademicYear, int BranchID);

    }
}
