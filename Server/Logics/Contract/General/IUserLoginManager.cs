using OrisonDailyReport.Shared.Entities.Login;

namespace OrisonDailyReport.Server.Logics.Contract.General
{
    public interface IUserLoginManager
    {
        public Task<List<DtoLoginModel>> GetUserData(int UserID, int BranchID, string key);

    }
}
