using BoldReports.DataExtensions.Odbc;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using OrisonDailyReport.Server.Logics.Contract.BoldReport;
using OrisonDailyReport.Server.Logics.Contract.General;
using OrisonDailyReport.Shared.Entities.General;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;

namespace OrisonDailyReport.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IDapperManager dapperManager;
        private readonly IBoldReportManager boldReportManager;

        public EmailController(IDapperManager dapperManager, IBoldReportManager boldReportManager)
        {
            this.dapperManager = dapperManager;
            this.boldReportManager = boldReportManager;
        }
        [HttpGet]
        [Route("EmailTemplate")]
        public async Task<IEnumerable<object>> GetEmailTemplate(int BranchID, string template, string key)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@BranchID", BranchID, DbType.Int32);
                dbPara.Add("@template", template, DbType.String);
                var templateDetails = await Task.FromResult(dapperManager.GetAll<object>("select * from School_MailTemplate where BranchID=@BranchID and Template=@template", key, dbPara, commandType: CommandType.Text));
                return templateDetails;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("clientDetails")]
        public async Task<List<Settings>> clientDetails(string key)
        {
            try
            {
                
                var templateDetails = await Task.FromResult(dapperManager.GetAll<Settings>("select * from School_EmailSettings", key, null, commandType: CommandType.Text));
                return templateDetails;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendMail(DtEmailSettings emailSettings)
        {
            try
            {
                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress(emailSettings.FromEmail, emailSettings.Company.CompanyName);
                    foreach (string mail in emailSettings.ToAddress)
                    {
                        message.To.Add(new MailAddress(mail));

                    }
                    message.Bcc.Add(new MailAddress(emailSettings.BCC_Mail));
                    foreach (string cc in emailSettings.ccAddress)
                    {
                        message.CC.Add(new MailAddress(cc));
                    }
                    //message.To.Add(new MailAddress("maheenazeez8@gmail.com"));
                    message.Subject = emailSettings.Subject;
                    message.IsBodyHtml = true;
                    message.Body = emailSettings.HTMLBody;

                    if(emailSettings.Attachment != null)
                    {

                        FileStreamResult filestream = await boldReportManager.GetReport(emailSettings.Attachment, emailSettings.Attachment.key);
                        message.Attachments.Add(new Attachment(filestream.FileStream, "Collection Summary.pdf"));
                    }
                    

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Port = emailSettings.Port;
                        smtp.Host = emailSettings.Host;
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        await smtp.SendMailAsync(message);
                    };
                };
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
