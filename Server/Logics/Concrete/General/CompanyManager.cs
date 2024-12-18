using Dapper;
using Microsoft.CodeAnalysis.Operations;
using OrisonDailyReport.Server.Logics.Contract.General;
using System.Data;

namespace OrisonDailyReport.Server.Logics.Concrete.General
{
    public class CompanyManager : ICompanyManager
    {
        private readonly IDapperManager dapperManager;

        public CompanyManager(IDapperManager dapperManager)
        {
            this.dapperManager = dapperManager;
        }

        public async Task<string> getLogo(int BranchID, string key)
        {
            var logo = Task.FromResult(dapperManager.Get<string>
                                ("Select LogoName from Company where ID='" + BranchID + "'", key, null, commandType: CommandType.Text));
            return await logo;
        }

        public async Task<string> getLogoUrl(string key)
        {
            var getLogoUrl = Task.FromResult(dapperManager.Get<string>
                                ("select Description from mastermisc where source='LogoPath'", key, null, commandType: CommandType.Text));
            return await getLogoUrl;
        }
        public async Task<string> GetCompanyCode(int branchId, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", branchId, DbType.Int32);
            var getLogoUrl = Task.FromResult(dapperManager.Get<string>
                                ("Select CompanyCode from Company Where ID = @BranchID", key, dbPara, commandType: CommandType.Text));
            return await getLogoUrl;
        }
        public Task<List<object>> GetCompanyDetails(int BranchID, string key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@BranchID", BranchID, DbType.Int32);
                var Company = Task.FromResult(dapperManager.GetAll<object>("select C.*,M.Description from company C cross join mastermisc M where M.Source='LogoPath' and C.ID=@BranchID", key, dbPara, commandType: CommandType.Text));
                return Company;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
