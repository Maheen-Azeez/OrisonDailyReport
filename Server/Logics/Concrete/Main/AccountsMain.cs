using Dapper;
using Microsoft.CodeAnalysis.Operations;
using OrisonDailyReport.Server.Logics.Concrete.General;
using OrisonDailyReport.Server.Logics.Contract.General;
using OrisonDailyReport.Server.Logics.Contract.Main;
using OrisonDailyReport.Shared.Entities.General;
using OrisonDailyReport.Shared.Entities.Registers;
using System.Data;
using System.Drawing;

namespace OrisonDailyReport.Server.Logics.Concrete.Main
{
    public class AccountsMain : IAccountsMain
    {
        private readonly IDapperManager _dapperManager;

        public AccountsMain(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }

        public async Task<List<dtAccountsMain>> GetCollections(int BranchId, string AccYear, DateTime SDate, DateTime EDate, string Description, string Criteria, string key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("branchid", BranchId, DbType.Int32);
                dbPara.Add("Accyear", AccYear, DbType.String);
                dbPara.Add("DateFrom ", Convert.ToDateTime(SDate).Date, DbType.Date);
                dbPara.Add("DateTo ", Convert.ToDateTime(EDate).Date, DbType.Date);
                dbPara.Add("Criteria", Criteria);
                var GridData = await Task.FromResult(_dapperManager.GetAll<dtAccountsMain>
                                    ("DailyRep_Registers_SP", key, dbPara,
                                    commandType: CommandType.StoredProcedure));
                return GridData;
            }
            catch (Exception EX)
            {

                throw EX;
            }
        }

        public async Task<List<string>> GetFeeType(string academicYear, int branchID, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@AcademicYear", academicYear, DbType.String);
            dbPara.Add("@BranchID", branchID, DbType.Int32);
            var StudentList = Task.FromResult(_dapperManager.GetAll<string>("SELECT  FeeSchedule FROM School_FeeSchedule s inner join School_AcademicYear a on s.AcademicYear=a.AcademicYear where a.AcademicYear=@AcademicYear and a.BranchID=@BranchID and s.BranchID=@BranchID and Type in ('Transportation','Fee')", key, dbPara, commandType: CommandType.Text));
            return await StudentList;
        }

        public async Task<IEnumerable<object>> GetDynamicFeewiseCollection(string AcademicYear, int BranchID, DateTime fromdate, DateTime todate, string key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@Accyear", AcademicYear, DbType.String);
                dbPara.Add("@BranchID", BranchID, DbType.Int32);
                dbPara.Add("@DateFrom", fromdate);
                dbPara.Add("@DateTo", todate);
                dbPara.Add("Criteria", "DynamicFeewiseCollection");
                var collection = await Task.FromResult(_dapperManager.GetAll<object>("[DailyRep_Registers_SP]", key, dbPara, commandType: CommandType.StoredProcedure));
                return collection;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IEnumerable<dtFeeWiseCollection>> GetFeewiseCollection(string AcademicYear, int BranchID, DateTime fromdate, DateTime todate, string key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@Accyear", AcademicYear, DbType.String);
                dbPara.Add("@BranchID", BranchID, DbType.Int32);
                dbPara.Add("@DateFrom", fromdate);
                dbPara.Add("@DateTo", todate);
                dbPara.Add("Criteria", "Fee_wiseCollection");
                var GridData = await Task.FromResult(_dapperManager.GetAll<dtFeeWiseCollection>("[DailyRep_Registers_SP]", key, dbPara, commandType: CommandType.StoredProcedure));
                return GridData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<SchoolCollectionDTO>> GetSchoolwiseCollection(string AcademicYear, int BranchID, DateTime fromdate, DateTime todate, string key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@Accyear", AcademicYear, DbType.String);
                dbPara.Add("@DateFrom", fromdate);
                dbPara.Add("@DateTo", todate);
                var GridData = await Task.FromResult(_dapperManager.GetAll<SchoolCollectionDTO>("[DailyRep_BranchCollectionsOverview]", key, dbPara, commandType: CommandType.StoredProcedure));
                return GridData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<DtItemStock>> GetItemStockSale(string academicYear, int branchID, DateTime fromdate, DateTime todate, string basicType, string key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@Accyear", academicYear, DbType.String);
                dbPara.Add("@BranchID", branchID, DbType.Int32);
                dbPara.Add("@DateFrom", fromdate);
                dbPara.Add("@DateTo", todate);
                dbPara.Add("@BasicType", basicType,DbType.String);
                dbPara.Add("Criteria", "ItemStockSale", DbType.String);
                var GridData = await Task.FromResult(_dapperManager.GetAll<DtItemStock>("[DailyRep_Registers_SP]", key, dbPara, commandType: CommandType.StoredProcedure));
                return GridData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<dtOnlineCollection>> GetOnlineCollection(string AcademicYear, int BranchID, DateTime fromdate, DateTime todate, string key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@Accyear", AcademicYear, DbType.String);
                dbPara.Add("@BranchID", BranchID, DbType.Int32);
                dbPara.Add("@DateFrom", fromdate);
                dbPara.Add("@DateTo", todate);
                dbPara.Add("Criteria", "OnlinePaymentDetails");
                var GridData = await Task.FromResult(_dapperManager.GetAll<dtOnlineCollection>("[DailyRep_Registers_SP]", key, dbPara, commandType: CommandType.StoredProcedure));
                return GridData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<dtAccountsMain>> GetUserwiseCollectionSummary(int BranchId, string AccYear, DateTime SDate, DateTime EDate, string Description, string Criteria, string userName, string key)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Criteria", Criteria, DbType.String);
            dbPara.Add("branchid", BranchId, DbType.Int32);
            dbPara.Add("Accyear", AccYear, DbType.String);
            dbPara.Add("DateFrom ", Convert.ToDateTime(SDate).Date, DbType.Date);
            dbPara.Add("DateTo ", Convert.ToDateTime(EDate).Date, DbType.Date);
            dbPara.Add("UserName", userName, DbType.String);

            var GridData = await Task.FromResult(_dapperManager.GetAll<dtAccountsMain>
                                ("[DailyRep_Registers_SP]", key, dbPara,
                                commandType: CommandType.StoredProcedure));
            return GridData;
        }
    }
}
