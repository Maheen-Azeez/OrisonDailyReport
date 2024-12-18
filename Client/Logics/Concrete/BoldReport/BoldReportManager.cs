using Blazored.SessionStorage;
using OrisonDailyReport.Client.Logics.Contract.BoldReport;
using OrisonDailyReport.Shared.Entities.BoldReport;
using Syncfusion.Blazor.Diagrams;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace OrisonDailyReport.Client.Logics.Concrete.BoldReport
{
    public class BoldReportManager : IBoldReportManager
    {
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService sessionStorage;
        private string? key;
        public BoldReportManager(HttpClient httpClient, ISessionStorageService sessionStorage)
        {
            this.httpClient = httpClient;
            this.sessionStorage = sessionStorage;
        }

        public async Task<MemoryStream> GetReport(DataSource Value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                key = HttpUtility.UrlEncode(await sessionStorage.GetItemAsync<string>("token_key"));
                res = await httpClient.PostAsJsonAsync("api/BoldReport/GetReport?key=" + key, Value);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            var ms = new MemoryStream();
            res.Content.CopyToAsync(ms).Wait();
            return res.IsSuccessStatusCode ? ms : null!;
        }
    }
}
