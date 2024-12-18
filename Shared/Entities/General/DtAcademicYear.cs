using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonDailyReport.Shared.Entities.General
{
    public class DtAcademicYear
    {
        public int Id { get; set; }
        public string? AcademicYear { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public int? Semester { get; set; }
        public int? Year { get; set; }
        public string AgeCalculationDate { get; set; }
        public string Admission { get; set; }
        public int? BranchId { get; set; }
        public string Principal { get; set; }
        public string PrincipalArb { get; set; }
        public string PrincipalSign { get; set; }
    }
}
