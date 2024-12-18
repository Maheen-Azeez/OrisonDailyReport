using Blazored.SessionStorage;
using Newtonsoft.Json;
using OrisonDailyReport.Client.Logics.Concrete.BoldReport;
using OrisonDailyReport.Shared.Entities.BoldReport;
using OrisonDailyReport.Shared.Entities.General;
using Syncfusion.Blazor.Diagram;
using Syncfusion.Blazor.RichTextEditor;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security;
using System.Web;

namespace OrisonDailyReport.Client.Services
{
    public class MailService
    {
        private readonly ISessionStorageService SessionStorage;
        private readonly HttpClient http;
        private string? key;
        private List<Settings> client;
        private DtEmailSettings emailSettings;

        public MailService(HttpClient httpClient, ISessionStorageService SessionStorage)
        {
            http = httpClient;
            this.SessionStorage = SessionStorage;

        }
        public async Task<List<ExpandoObject>> GetEmailTemplate(string template, int branchID, string Con)
        {
            List<ExpandoObject> Result = new List<ExpandoObject>();
            try
            {
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                var Data = await http.GetFromJsonAsync<IEnumerable<object>>("API/Email/EmailTemplate?BranchID=" + branchID + "&template=" + template + "&key=" + key);
                foreach (var dt in Data)
                    Result.Add(JsonConvert.DeserializeObject<ExpandoObject>(dt.ToString()));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }
        public async Task<int> SendEmailAsync(string ToEmail, string Subject, string HTMLBody, object GridData, object CompanyDetails, string fromDate, string toDate, string Con)
        {
            try
            {
                emailSettings = new DtEmailSettings();
                client = new List<Settings>();
                emailSettings.Company = new Company();
                emailSettings.Company.BranchID = await SessionStorage.GetItemAsync<int>("BranchID");
                emailSettings.Company.CompanyName = await SessionStorage.GetItemAsync<string>("CompanyFullName");
                int BranchID = emailSettings.Company.BranchID;
                key = HttpUtility.UrlEncode(await SessionStorage.GetItemAsync<string>("token_key"));
                client = await GetClientDetailsAsync(key);
                
                var host = client.Where(data => data.Category == "MailSmtpServer" && data.BranchID == BranchID).Select(data => data.Value).ToList();
                var fromEmail = client.Where(data => data.Category == "MailFromAddress" && data.BranchID == BranchID).Select(data => data.Value).ToList();
                var port = client.Where(data => data.Category == "SMTPPort" && data.BranchID == BranchID).Select(data => data.Value).ToList();
                var ecryptedPassword = client.Where(data => data.Category == "MailPassword" && data.BranchID == BranchID).Select(data => data.Value).ToList();
                var userName = client.Where(data => data.Category == "MailUserName" && data.BranchID == BranchID).Select(data => data.Value).ToList();
                var bccMail = client.Where(data => data.Category == "DCSBccMail" && data.BranchID == BranchID).Select(data => data.Value).ToList();
                var ccMail = client.Where(data => data.Category == "DCSCcMail" && data.BranchID == BranchID).Select(data => data.Value).ToList();
                var toEmail = client.Where(data => data.Category == "DCSToMail" && data.BranchID == BranchID).Select(data => data.Value).ToList();
                emailSettings.HTMLBody = HTMLBody;
                emailSettings.Subject = Subject;
                emailSettings.Host = string.Join(Environment.NewLine, host);
                emailSettings.FromEmail = string.Join(Environment.NewLine, fromEmail);
                emailSettings.Username = string.Join(Environment.NewLine, userName);
                emailSettings.BCC_Mail = string.Join(Environment.NewLine, bccMail);
                emailSettings.Port = Convert.ToInt32(string.Join(Environment.NewLine, port));
                string CC_Mail = string.Join(Environment.NewLine, ccMail);
                string To_Mail = string.Join(Environment.NewLine, toEmail);
                var password = string.Join(Environment.NewLine, ecryptedPassword);
                emailSettings.ToAddress = To_Mail.Split(',');
                emailSettings.ccAddress = CC_Mail.Split(',');
                emailSettings.Password = PasswordDecode(password);
                emailSettings.Attachment = new DataSource();
                emailSettings.Attachment.Parameters = new List<JSReportParameter>()
                {
                     new JSReportParameter()
                     {
                        Name = "DateFrom",
                        Values = new List<string>(){ fromDate.ToString() }
                     },
                     new JSReportParameter()
                     {
                        Name = "DateTo",
                        Values = new List<string>(){ toDate.ToString() }
                     }
                };
                emailSettings.Attachment.DataSet1 = JsonConvert.DeserializeObject<List<ExpandoObject>>(JsonConvert.SerializeObject(GridData));
                emailSettings.Attachment.Company = JsonConvert.DeserializeObject<List<ExpandoObject>>(JsonConvert.SerializeObject(CompanyDetails));

                var result = http.PostAsJsonAsync("api/Email/send",emailSettings);
                
                //Host = "Smtp.Office365.Com";
                //Port = 587;
                //FromEmail = "noreply@DubaiScholars.com";
                //Password = "Dss@2050";

                //using (MailMessage message = new MailMessage())
                //{
                //    message.From = new MailAddress(FromEmail, CompanyName);
                //    foreach (string mail in ToAddress)
                //    {
                //        message.To.Add(new MailAddress(mail));

                //    }
                //    message.Bcc.Add(new MailAddress(BCC_Mail));
                //    foreach (string cc in ccAddress)
                //    {
                //        message.CC.Add(new MailAddress(cc));
                //    }
                //    message.Subject = Subject;
                //    message.IsBodyHtml = true;
                //    message.Body = HTMLBody;
                //    List<JSReportParameter> parameters = new List<JSReportParameter>()
                //    {
                //        new JSReportParameter()
                //        {
                //            Name = "fromDate",
                //            Values = new List<string>(){ fromDate.ToString() }
                //        },
                //        new JSReportParameter()
                //        {
                //        Name = "toDate",
                //        Values = new List<string>(){ toDate.ToString() }
                //        }
                //    };
                //    DataSource dt = new DataSource();
                //    dt.DataSet1 = new List<ExpandoObject>();
                //    dt.Company = new List<ExpandoObject>();
                //    dt.DataSet1 = JsonConvert.DeserializeObject<List<ExpandoObject>>(JsonConvert.SerializeObject(GridData));
                //    dt.Company = JsonConvert.DeserializeObject<List<ExpandoObject>>(JsonConvert.SerializeObject(CompanyDetails));
                //    await http.postasjsonasync("api/");
                //    filestreamresult filestream = await boldreportmanager.getreport("dashboard", dt, parameters, "", con, 0);

                //    message.Attachments.Add(new Attachment(fileStream.FileStream, "Collection Summary.pdf"));

                //    using (SmtpClient smtp = new SmtpClient())
                //    {
                //        smtp.Port = Port;
                //        smtp.Host = Host;
                //        smtp.EnableSsl = true;
                //        smtp.UseDefaultCredentials = false;
                //        smtp.Credentials = new NetworkCredential(Username, Password);
                //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //        await smtp.SendMailAsync(message);
                        return 1;
                //    };
                //};

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<Settings>> GetClientDetailsAsync(string key)
        {
            try
            {
                var clientDetails = await http.GetFromJsonAsync<List<Settings>>("api/Email/clientDetails?key=" + key);
                return clientDetails;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string PasswordDecode(string Pwd)
        {
            char[] PwdChar = Pwd.ToCharArray();
            string deCodedPwd = "";
            foreach (char c in PwdChar)
            {
                deCodedPwd = deCodedPwd + (char)(Convert.ToInt32(c) - 10);
            }
            return deCodedPwd;
        }
        public string PasswordEncode(string Pwd)
        {
            char[] PwdChar = Pwd.ToCharArray();
            string EnCodedPwd = "";
            foreach (char c in PwdChar)
            {
                EnCodedPwd = EnCodedPwd + (char)(Convert.ToInt32(c) + 10);
            }
            return EnCodedPwd;

        }

    }
}
