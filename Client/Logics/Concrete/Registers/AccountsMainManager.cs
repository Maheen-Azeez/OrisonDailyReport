using Blazored.SessionStorage;
using Newtonsoft.Json;
using OrisonDailyReport.Client.Logics.Contract.Registers;
using OrisonDailyReport.Shared.Entities.Registers;
using System.Dynamic;
using System.Net.Http.Json;
using System.Web;

namespace OrisonDailyReport.Client.Logics.Concrete.Registers
{
    public class AccountsMainManager : IAccountsMain
    {
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService sessionStorage;
        string? key;
        public AccountsMainManager(HttpClient httpClient, ISessionStorageService sessionStorage)
        {
            this.httpClient = httpClient;
            this.sessionStorage = sessionStorage;
        }
        public async Task<IEnumerable<dtAccountsMain>> GetCollections(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria)
        {
            try
            {
                key = HttpUtility.UrlEncode(await sessionStorage.GetItemAsync<string>("token_key"));
                var data = httpClient.GetFromJsonAsync<IEnumerable<dtAccountsMain>>("API/AccountsMain/Collections?BranchId=" + BranchId + "&AccYear=" + AccYear + "&SDate=" + SDate + "&EDate=" + EDate + "&Description=" + Description + "&Criteria=" + Criteria + "&key=" + key);
                return await data;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<IEnumerable<string>> GetFeeType(string AcademicYear, int BranchID)
        {
            key = HttpUtility.UrlEncode(await sessionStorage.GetItemAsync<string>("token_key"));
            return await httpClient.GetFromJsonAsync<IEnumerable<string>>("API/AccountsMain/GetFeeType?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&key=" + key);
        }

        public async Task<List<ExpandoObject>> GetDynamicFeewiseCollection(string AcademicYear, int BranchID, string fromdate, string todate)
        {
            List<ExpandoObject> Result = new List<ExpandoObject>();
            try
            {
                key = HttpUtility.UrlEncode(await sessionStorage.GetItemAsync<string>("token_key"));
                var job = await httpClient.GetFromJsonAsync<IEnumerable<object>>("api/AccountsMain/DynamicFeewiseCollection?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&fromdate=" + fromdate + "&todate=" + todate + "&key=" + key);
                foreach (var dt in job)
                    Result.Add(JsonConvert.DeserializeObject<ExpandoObject>(dt.ToString()));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }
        public async Task<IEnumerable<dtFeeWiseCollection>> GetFeewiseCollection(string AcademicYear, int BranchID, string fromdate, string todate)
        {
            key = HttpUtility.UrlEncode(await sessionStorage.GetItemAsync<string>("token_key"));
            var data = await httpClient.GetFromJsonAsync<IEnumerable<dtFeeWiseCollection>>("api/AccountsMain/FeewiseCollection?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&fromdate=" + fromdate + "&todate=" + todate + "&key=" + key);
            return data;
        } 
        public async Task<IEnumerable<SchoolCollectionDTO>> GetSchoolwiseCollection(string AcademicYear, int BranchID, string fromdate, string todate)
        {
            key = HttpUtility.UrlEncode(await sessionStorage.GetItemAsync<string>("token_key"));
            var data = await httpClient.GetFromJsonAsync<IEnumerable<SchoolCollectionDTO>>("api/AccountsMain/SchoolwiseCollection?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&fromdate=" + fromdate + "&todate=" + todate + "&key=" + key);
            return data;
        } 
        public async Task<IEnumerable<DtItemStock>> GetItemStockSale(string AcademicYear, int BranchID, string fromdate, string todate, string basicType)
        {
            try
            {
                key = HttpUtility.UrlEncode(await sessionStorage.GetItemAsync<string>("token_key"));
                var data = await httpClient.GetFromJsonAsync<IEnumerable<DtItemStock>>("api/AccountsMain/ItemStockSale?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&fromdate=" + fromdate + "&todate=" + todate + "&basicType=" + basicType + "&key=" + key);
                return data;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<IEnumerable<dtOnlineCollection>> GetOnlineCollection(string AcademicYear, int BranchID, string fromdate, string todate)
        {
            key = HttpUtility.UrlEncode(await sessionStorage.GetItemAsync<string>("token_key"));
            var data = httpClient.GetFromJsonAsync<IEnumerable<dtOnlineCollection>>("API/AccountsMain/OnlineCollection?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&fromdate=" + fromdate + "&todate=" + todate + "&key=" + key);
            return await data;
        }

        public async Task<IEnumerable<dtAccountsMain>> GetUserwiseCollectionSummary(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria, string userName)
        {
            key = HttpUtility.UrlEncode(await sessionStorage.GetItemAsync<string>("token_key"));
            var GridData = httpClient.GetFromJsonAsync<IEnumerable<dtAccountsMain>>("API/AccountsMain/GetUserwiseCollectionSummary?BranchId=" + BranchId + "&AccYear=" + AccYear + "&SDate=" + SDate + "&EDate=" + EDate + "&Description=" + Description + "&Criteria=" + Criteria + "&userName=" + userName + "&key=" + key);
            return await GridData;
        }
    }
}
