using System.Dynamic;

namespace OrisonDailyReport.Client.Logics.Contract.General
{
    public interface ICompanyManager
    {
        Task<string> getLogo(int BranchID);
        Task<string> getLogoUrl();
        public Task<List<ExpandoObject>> GetCompanyDetails(int BranchID);
        public Task<string> GetCompanyCode(int BranchID);
    }
}
