using BoldReports.Writer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Dynamic;

namespace OrisonDailyReport.Server.Controllers.BoldReport
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportViewerController : ControllerBase
    {
        public ReportViewerController()
        {
                
        }
        //public async Task<IActionResult> Export(string Parameter)
        //{
        //    AbsentParent absentParent = System.Text.Json.JsonSerializer.Deserialize<AbsentParent>(Parameter);
        //    Shared.Entities.BoldReport.DataSource DataSets = new Shared.Entities.BoldReport.DataSource();
        //    DataSets.DataSet1 = JsonConvert.DeserializeObject<List<ExpandoObject>>(JsonConvert.SerializeObject(await _repository.GetFireRegister(absentParent)));
        //    DataSets.DataSet2 = new List<ExpandoObject>();
        //    string HostPath = @"D:\Efru\";
        //    string PathWithCustom = Path.Combine(HostPath, @$"Attendance\Custom\{absentParent.CompanyCode}", $"{absentParent.ReportName}.rdl");
        //    string PathWithoutCustom = Path.Combine(HostPath, @"Attendance\", $"{absentParent.ReportName}.rdl");
        //    string filePath = System.IO.File.Exists(PathWithCustom) ? PathWithCustom : PathWithoutCustom;
        //    filePath = PathWithoutCustom;//Addded
        //    FileStreamResult fileStreamResult = GetReport(DataSets, filePath, "pdf");
        //    fileStreamResult.FileDownloadName = absentParent.ReportName + ".pdf";
        //    return fileStreamResult;
        //}
        public FileStreamResult GetReport(Shared.Entities.BoldReport.DataSource DataSets, string ReportName, string Mode)
        {
            FileStream inputStream = new FileStream(ReportName, FileMode.Open, FileAccess.Read);
            MemoryStream reportStream = new MemoryStream();
            inputStream.CopyTo(reportStream);
            reportStream.Position = 0;
            inputStream.Close();
            ReportWriter writer = new ReportWriter();

            writer.ExportResources.Scripts = new List<string>
            {
                //Gauge component scripts
                "https://cdn.boldreports.com/5.1.28/scripts/common/ej2-base.min.js",
                "https://cdn.boldreports.com/5.1.28/scripts/common/ej2-data.min.js",
                "https://cdn.boldreports.com/5.1.28/scripts/common/ej2-pdf-export.min.js",
                "https://cdn.boldreports.com/5.1.28/scripts/common/ej2-svg-base.min.js",
                "https://cdn.boldreports.com/5.1.28/scripts/data-visualization/ej2-lineargauge.min.js",
                "https://cdn.boldreports.com/5.1.28/scripts/data-visualization/ej2-circulargauge.min.js",
                //Map component script
                "https://cdn.boldreports.com/5.1.28/scripts/data-visualization/ej2-maps.min.js",
                "https://cdn.boldreports.com/5.1.28/scripts/common/bold.reports.common.min.js",
                "https://cdn.boldreports.com/5.1.28/scripts/common/bold.reports.widgets.min.js",
                //Chart component script
                "https://cdn.boldreports.com/5.1.28/scripts/data-visualization/ej.chart.min.js",
                 //Report Viewer Script
                "https://cdn.boldreports.com/5.1.28/scripts/bold.report-viewer.min.js",
                "https://cdn.boldreports.com/5.1.28/scripts/l10n/ej.localetexts.ar-AE.min.js",
                "https://cdn.boldreports.com/5.1.28/scripts/i18n/ej.culture.ar-AE.min.js",
                "https://cdn.boldreports.com/5.1.28/scripts/i18n/ej.culture.ku-Arab-IQ.min.js"
            };

            writer.ExportResources.DependentScripts = new List<string>
            {
                "https://code.jquery.com/jquery-1.10.2.min.js"
            };

            writer.LoadReport(reportStream);

            writer.ReportProcessingMode = BoldReports.Writer.ProcessingMode.Local;
            writer.DataSources.Clear();

            var dataSets = new List<IEnumerable<object>>
            {
                DataSets.DataSet1, DataSets.DataSet2, DataSets.DataSet3, DataSets.DataSet4, DataSets.DataSet5,
                DataSets.DataSet6, DataSets.DataSet7, DataSets.DataSet8, DataSets.DataSet9, DataSets.DataSet10
            };

            for (int i = 0; i < dataSets.Count; i++)
            {
                if (dataSets[i] != null)
                {
                    writer.DataSources.Add(new BoldReports.Web.ReportDataSource
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

            MemoryStream memoryStream = new MemoryStream();
            WriterFormat format = Mode == "Excel" ? WriterFormat.Excel : WriterFormat.PDF;
            writer.Save(memoryStream, format);

            memoryStream.Position = 0;
            return new FileStreamResult(memoryStream, "application/" + (Mode == "Excel" ? "xlsx" : "pdf"));
        }
    }
}
