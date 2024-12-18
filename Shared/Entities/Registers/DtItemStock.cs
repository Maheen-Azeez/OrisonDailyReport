using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonDailyReport.Shared.Entities.Registers
{
    public class DtItemStock
    {
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? Category { get; set; }
        public string? MajorGroup { get; set; }
        public string? MiddleGroup { get; set; }
        public int ID { get; set; }
        public int VID { get; set; }
        public int ItemID { get; set; }
        public int Qty { get; set; }
        public string? Vtype { get; set; }
        public decimal Rate { get; set; }
        public string? Unit { get; set; }
        public decimal Amount { get; set; }
        public string? VNo { get; set; }
        public DateTime? VDate { get; set; }
        public string? StaffName { get; set; }
        public string? PartyName { get; set; }
        public string? ProjectCode { get; set; }
        public string? Project { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public string? Class { get; set; }
        public decimal Vat { get; set; }
    }
}
