using Blazored.SessionStorage;
using Newtonsoft.Json;
using OrisonDailyReport.Client.Logics.Contract.General;
using System.Dynamic;
using System.Net.Http.Json;
using System.Web;

namespace OrisonDailyReport.Client.Logics.Concrete.General
{
    public class CompanyManager : ICompanyManager
    {

        private readonly HttpClient httpClient;
        private readonly ISessionStorageService SessionStorage;
        string? key;
        public CompanyManager(HttpClient httpClient, ISessionStorageService SessionStorage)
        {
            this.httpClient = httpClient;
            this.SessionStorage = SessionStorage;

        }
        public async Task<string> getLogo(int BranchID)
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetStringAsync("api/Company/getLogo?BranchID=" + BranchID + "&key=" + key);
        }

        public async Task<string> getLogoUrl()
        {
            key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetStringAsync("api/Company/getLogoUrl?key=" + key);
        }
        public async Task<List<ExpandoObject>> GetCompanyDetails(int BranchID)
        {

            List<ExpandoObject> Result = new List<ExpandoObject>();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var job = await httpClient.GetFromJsonAsync<IEnumerable<object>>("api/Company/CompanyDetails?BranchID=" + BranchID + "&key=" + key);
                foreach (var dt in job)
                    Result.Add(JsonConvert.DeserializeObject<ExpandoObject>(dt.ToString()));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }
        public async Task<string> GetCompanyCode(int BranchID)
        {

            List<ExpandoObject> Result = new List<ExpandoObject>();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                return await httpClient.GetStringAsync("api/Company/CompanyCode?BranchID=" + BranchID + "&key=" + key);
              

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
