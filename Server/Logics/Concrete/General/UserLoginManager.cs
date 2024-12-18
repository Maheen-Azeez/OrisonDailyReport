using Dapper;
using OrisonDailyReport.Server.Logics.Contract.General;
using OrisonDailyReport.Shared.Entities.Login;
using System.Data;

namespace OrisonDailyReport.Server.Logics.Concrete.General
{
    public class UserLoginManager : IUserLoginManager
    {
        private readonly IDapperManager _dapperManager;
        public UserLoginManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }
        public async Task<List<DtoLoginModel>> GetUserData(int UserID, int BranchID, string key)
        {
            List<DtoLoginModel> UData = new List<DtoLoginModel>();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("userid", UserID, DbType.Int32);
                dbPara.Add("BranchId", BranchID, DbType.Int32);
                dbPara.Add("Criteria", "Autologin", DbType.String);
                UData = await Task.FromResult(_dapperManager.GetAll<DtoLoginModel>
                                    ("[DailyRep_PortalUserLogin_SP]", key, dbPara,
                                    CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {

            }
            return UData;
        }
    }
}
