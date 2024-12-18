using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonDailyReport.Shared.Entities.Registers
{
    public class dtAccountsMain
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string AcademicYear { get; set; }
        public string SDate { get; set; }
        public DateTime VDate { get; set; }
        public string EDate { get; set; }
        public string VType { get; set; }
        public string Vno { get; set; }
        public string Children { get; set; }
        public DateTime FeesDate { get; set; }
        public DateTime Date { get; set; }
        public string StudentCode { get; set; }
        public string ReceiptNo { get; set; }
        public decimal Others { get; set; }
        public string StudentName { get; set; }
        public string AdmissionStatus { get; set; }
        public string ChequeDetails { get; set; }
        public string CardDetails { get; set; }
        public string PaymentReference { get; set; }
        public string Class { get; set; }
        public string Division { get; set; }
        public string AccountName { get; set; }
        public string AccountCode { get; set; }
        public string Description { get; set; }
        public string Feetype { get; set; }
        public decimal Cash { get; set; }
        public decimal T1Cash { get; set; }
        public decimal T1Cheque { get; set; }
        public decimal T1Card { get; set; }
        public decimal T1TT { get; set; }
        public decimal Cheque { get; set; }
        public decimal Card { get; set; }
        public decimal TT { get; set; }
        public decimal T2Cash { get; set; }
        public decimal T2Cheque { get; set; }
        public decimal T2Card { get; set; }
        public decimal T2TT { get; set; }
        public decimal T3Cash { get; set; }
        public decimal T3Cheque { get; set; }
        public decimal T3Card { get; set; }
        public decimal T3TT { get; set; }
        public decimal OnlinePayment { get; set; }
        public int Count { get; set; }
        public decimal Total { get; set; }
        public decimal ReregistrationFee { get; set; }
        public decimal TransportationFee { get; set; }
        public decimal BookFee { get; set; }
        public decimal TuitionTerm1 { get; set; }
        public decimal TuitionTerm2 { get; set; }
        public decimal TuitionTerm3 { get; set; }
        public decimal Transfer { get; set; }
        public int? EmployeeID { get; set; }
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public int Capacity { get; set; }
        public int BoysDivision { get; set; }
        public int GirlDivision { get; set; }
        public int TotalDivision { get; set; }
        public int BoysSeat { get; set; }
        public int GirlSeat { get; set; }
        public int TotalSeat { get; set; }
        public int NewBoysPaid { get; set; }
        public int NewGirlsPaid { get; set; }
        public int NewTotalPaid { get; set; }
        public int OldBoysPaid { get; set; }
        public int OldGirlsPaid { get; set; }
        public int OldFeePaid { get; set; }
        public int MaleExemption { get; set; }
        public int FemaleExemption { get; set; }
        public int TotalExemption { get; set; }
        public int MaleSeatFilled { get; set; }
        public int FemaleSeatFilled { get; set; }
        public int TotalSeatFilled { get; set; }
        public int MaleVacancy { get; set; }
        public int FemaleVacancy { get; set; }
        public int TotalVacancy { get; set; }
        public int MaleReserved { get; set; }
        public int FemaleReserved { get; set; }
        public int Reserved { get; set; }
        public decimal TUITIONFEE { get; set; }
        public decimal DEVELOPMENTFEE { get; set; }
        public decimal AnnualFees { get; set; }
        public decimal PTAFee { get; set; }
        public decimal AdmFee { get; set; }
        public decimal CompIpFee { get; set; }
        public decimal ScienceLabsFee { get; set; }
        public decimal LATEFEEFINE { get; set; }
        public decimal PFund { get; set; }
        public string Mode { get; set; }
        public decimal Amount { get; set; }
    }
}
