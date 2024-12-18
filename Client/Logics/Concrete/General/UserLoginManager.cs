using Blazored.SessionStorage;
using OrisonDailyReport.Client.Logics.Contract.General;
using OrisonDailyReport.Shared.Entities.Login;
using System.Net.Http.Json;
using System.Web;

namespace OrisonDailyReport.Client.Logics.Concrete.General
{
    public class UserLoginManager : IUserLoginManager
    {
        private string? key;
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        public UserLoginManager(HttpClient httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = _SessionStorage;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of any managed resources here
            }
            // Dispose of any unmanaged resources here
        }

        public async Task<IEnumerable<DtoLoginModel>?> GetUserData(int? UserID, int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<DtoLoginModel[]>("API/UserLogin?UserID=" + UserID + "&BranchID=" + BranchID + "&Key=" + key);
        }

        public async Task<IEnumerable<DtoLoginModel>?> LoginUser(string UserName, string Password)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<DtoLoginModel[]>("API/Login/LoginUser?UserName=" + UserName + "&Password=" + Password + "&Key=" + key);
        }

    }
}
