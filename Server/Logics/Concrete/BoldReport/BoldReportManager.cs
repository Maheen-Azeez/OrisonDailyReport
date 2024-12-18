using BoldReports.Web;
using BoldReports.Writer;
using Microsoft.AspNetCore.Mvc;
using OrisonDailyReport.Server.Logics.Contract.BoldReport;
using OrisonDailyReport.Server.Logics.Contract.General;
using OrisonDailyReport.Shared.Entities.BoldReport;
using System.Data;

namespace OrisonDailyReport.Server.Logics.Concrete.BoldReport
{
    public class BoldReportManager : IBoldReportManager
    {
        private readonly IDapperManager dapperManager;

        public BoldReportManager(IDapperManager dapperManager)
        {
            this.dapperManager = dapperManager;
        }

        public async Task<FileStreamResult> GetReport(DataSource Data, string key)
        {
            try
            {
                string HostPath = await GetReportPath(key);
                //HostPath = @"C:\\Users\\MSI\\Pictures\\Mufy\\Reports\\Reports\\Smart Vision";
                //HostPath = @"C:\Users\mahee\Desktop\DailyReports\Reports";
                //string PathWithCustom = Path.Combine(HostPath, @$"Students\Custom\{Data.CompanyCode}", $"{Data.ReportName}.rdl");
                //string PathWithoutCustom = Path.Combine(HostPath, @"Students\", $"{Data.ReportName}.rdl");
                //string filePath = File.Exists(PathWithCustom) ? PathWithCustom : PathWithoutCustom;

                string filePath = Path.Combine(HostPath, $"{Data.ReportName}.rdl");

                using (FileStream inputStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (MemoryStream reportStream = new MemoryStream())
                {
                    inputStream.CopyTo(reportStream);
                    reportStream.Position = 0;
                    inputStream.Close();
                    ReportWriter writer = new ReportWriter(reportStream);
                    writer.ReportProcessingMode = ProcessingMode.Local;
                    writer.DataSources.Clear();

                    var dataSets = new List<IEnumerable<object>>
                    {
                        Data.DataSet1!,Data.DataSet2!, Data.DataSet3!, Data.DataSet4!, Data.DataSet5!,
                        Data.DataSet6!, Data.DataSet7!, Data.DataSet8!, Data.DataSet9!, Data.DataSet10!
                    };

                    for (int i = 0; i < dataSets.Count; i++)
                    {
                        if (dataSets[i] != null)
                        {
                            writer.DataSources.Add(new ReportDataSource
                            {
                                Name = $"DataSet{i + 1}",
                                Value = dataSets[i].ToList()
                            });
                        }
                        else
                        {

                            break;
                        }
                    }
                    if(Data.Company != null)
                    {
                        writer.DataSources.Add(new ReportDataSource
                        {
                            Name = $"Company",
                            Value = Data.Company.ToList()
                        });
                    }
                    List<ReportParameter> userParameters = new List<BoldReports.Web.ReportParameter>();
                    if (Data.Parameters != null)
                    {
                        for (int i = 0; i < Data.Parameters.Count(); i++)
                        {
                            userParameters.Add(new ReportParameter()
                            {
                                Name = Data.Parameters[i].Name,
                                Values = new List<string>() { Data.Parameters[i].Values[0].ToString() }
                            }); ;
                        }
                    }
                    writer.SetParameters(userParameters);
                    string fileName = $"{Data.ReportName}.pdf";
                    WriterFormat format = WriterFormat.PDF;
                    string contentType = "application/pdf";

                    MemoryStream memoryStream = new MemoryStream();
                    writer.Save(memoryStream, format);

                    memoryStream.Position = 0;
                    FileStreamResult fileStreamResult = new FileStreamResult(memoryStream, contentType);
                    fileStreamResult.FileDownloadName = fileName;
                    return fileStreamResult;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private async Task<string> GetReportPath(string? key)
        {
            try
            {
                var Result = Task.FromResult(dapperManager.Get<string>
                    ("select Description from MasterMisc where Source='DailyReport Path'", key, null, commandType: CommandType.Text));
                return await Result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
