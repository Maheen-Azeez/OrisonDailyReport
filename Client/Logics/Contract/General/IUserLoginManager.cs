using OrisonDailyReport.Shared.Entities.Login;

namespace OrisonDailyReport.Client.Logics.Contract.General
{
    public interface IUserLoginManager
    {
        public Task<IEnumerable<DtoLoginModel>?> GetUserData(int? UserID, int? BranchID);
        public Task<IEnumerable<DtoLoginModel>?> LoginUser(string UserName, string Password);
    }
}
