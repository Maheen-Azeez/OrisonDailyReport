using Dapper;
using OrisonDailyReport.Server.Logics.Contract.General;
using OrisonDailyReport.Shared.Entities.General;
using OrisonDailyReport.Shared.Entities.Login;
using OrisonDailyReport.Shared.Entities.Registers;
using System.Data;
using System.Xml.Linq;

namespace OrisonDailyReport.Server.Logics.Concrete.General
{
    public class DBOperationManager : IDBOperationManager
    {
        private readonly IDapperManager dapperManager;

        public DBOperationManager(IDapperManager dapperManager)
        {
            this.dapperManager = dapperManager;
        }
        public async Task<string> GetURL(string Source, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("value", Source, System.Data.DbType.String);
            var data = await Task.FromResult(dapperManager.Get<string>
                                   ("select Description from mastermisc where source = @value", key, dbPara,
                                   CommandType.Text));
            return data.ToString();
        }
        public async Task<List<DtAcademicYear>> GetAcademicYear(int BranchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.String);
            var AcedemicYear = Task.FromResult(dapperManager.GetAll<DtAcademicYear>("select * from School_AcademicYear where BranchID=@BranchID", key, dbPara, commandType: CommandType.Text));
            return await AcedemicYear;
        }
        public async Task<List<dtAccountsMain>> GetUserName(string key)
        {
            var AcedemicYear = Task.FromResult(dapperManager.GetAll<dtAccountsMain>("Select Name as UserName from PortalUsers", key, null, commandType: CommandType.Text));
            return await AcedemicYear;
        }

        public Task<string> GetCurrentAcademicYear(int BranchID, string Key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@BranchID", BranchID, DbType.Int32);
            var Company = Task.FromResult(dapperManager.Get<string>("Select AcademicYear from School_AcademicYear where Status='Current' and BranchID=@BranchID", Key, dbPara, commandType: CommandType.Text));
            return Company;
        }
    }
    
}
