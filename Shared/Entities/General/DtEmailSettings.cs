using OrisonDailyReport.Shared.Entities.BoldReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonDailyReport.Shared.Entities.General
{
    public class DtEmailSettings
    {
        public object GridData { get; set; }
        public Company Company { get; set; }
        public string? Host { get; set; }
        public string? FromEmail { get; set; }
        public string? Username { get; set; }
        public string? BCC_Mail { get; set; }
        public string? Password { get; set; }
        public string[] ToAddress { get; set; }
        public string HTMLBody { get; set; }
        public string Subject { get; set; }
        public string[] ccAddress { get; set; }
        public int Port { get; set; }
        public DataSource Attachment { get; set; }
    }
}
