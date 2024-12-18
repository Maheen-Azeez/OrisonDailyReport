namespace OrisonDailyReport.Client.Services
{
    public class CacheVersionService
    {
        private readonly HttpClient _httpClient;
        public CacheVersionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetCacheVersion()
        {
            try
            {
                return await _httpClient.GetStringAsync("api/CacheVersion/GetVersion");
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
    }
}
