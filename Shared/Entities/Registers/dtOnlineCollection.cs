using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonDailyReport.Shared.Entities.Registers
{
    public class dtOnlineCollection
    {
        public int ID { get; set; }
        public int DocNo { get; set; }
        public DateTime TranDate { get; set; }
        public int Order_No { get; set; }
        public string StudentName { get; set; }
        public int ReferenceID { get; set; }
        public int TransactionID { get; set; }
        public int ReferenceDocNo { get; set; }
        public int EnrollNo { get; set; }
        public int CardNo { get; set; }
        public string PaymentMode { get; set; }
        public int Status { get; set; }
        public int TransactionStatus { get; set; }
        public decimal Amount { get; set; }
        public string VNo { get; set; }
        public DateTime VDate { get; set; }
        public string AccountName { get; set; }
        public string Accountcode { get; set; }
        public decimal OnlinePayment { get; set; }
        public decimal Total { get; set; }
    }
}
