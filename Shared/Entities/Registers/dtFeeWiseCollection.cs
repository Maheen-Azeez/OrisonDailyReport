using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonDailyReport.Shared.Entities.Registers
{
    public class dtFeeWiseCollection
    {
        public string? VNo { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string? StudentCode { get; set; }
        public string? StudentName { get; set; }
        public string? Class { get; set; }
        public string? Division { get; set; }
        public string? UserName { get; set; }
        public decimal? TuitionFee { get; set; }
        public decimal? ExamFee { get; set; }
        public decimal? TCFee { get; set; }
        public decimal? Admission { get; set; }
        public decimal? Sales { get; set; }
        public decimal? Opening { get; set; }
        public decimal? Others { get; set; }
        public decimal? Cash { get; set; }
        public decimal? Card { get; set; }
        public decimal? Cheque { get; set; }
        public decimal? TT { get; set; }
        public decimal? OnlinePayment { get; set; }
        public decimal? Total { get; set; }
    }
}
