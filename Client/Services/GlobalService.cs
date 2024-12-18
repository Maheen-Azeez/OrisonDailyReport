using Blazored.SessionStorage;
using System.Web;

namespace OrisonDailyReport.Client.Services
{
    public class GlobalService
    {
        private string? key;
        private string? globalCurrencyFormat;
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        public GlobalService(HttpClient _httpClient, ISessionStorageService _SessionStorage)
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
        public string? GlobalCurrencyFormat
        {
            get => globalCurrencyFormat;
            private set => globalCurrencyFormat = value;
        }
        public async Task<string> GetCurrencyMaster(int? BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            string result = await httpClient.GetStringAsync("API/GlobalService/CurrencyMaster?BranchID=" + BranchID + "&Key=" + key);
            GlobalCurrencyFormat = result;
            return result;
        }
    }
}
