using Blazored.SessionStorage;
using OrisonDailyReport.Shared.Entities.General;
using OrisonDailyReport.Shared.Entities.Registers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace OrisonDailyReport.Client.Services
{
    public class GeneralServices
    {
        private string? key;
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        public GeneralServices(HttpClient _httpClient, ISessionStorageService _SessionStorage)
        {
            this.httpClient = _httpClient;
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
        public async Task<DateTime> GetServerDateTime()
        {
            var response = await httpClient.GetAsync("API/DBOperation/GetDate");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DateTime>();
        }
        public async Task<string?> GetURL(string? source)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetStringAsync("API/DBOperation/URL?Source=" + source + "&key=" + key);
        }
        public async Task<IEnumerable<dtAccountsMain>> GetUserName()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<dtAccountsMain>>("API/DBOperation/UserName?key=" + key);
        }
        public async Task<IEnumerable<DtAcademicYear>?> GetAcademicYear(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<DtAcademicYear>>("API/DBOperation?BranchID=" + BranchID + "&Key=" + key);
        }
        public async Task<string> GetCurrentAcademicYear(int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            var AcademicYear = await httpClient.GetStringAsync("API/DBOperation/CurrentYear?BranchID=" + BranchID + "&Key=" + key);
            return AcademicYear;
        }
    }
}
