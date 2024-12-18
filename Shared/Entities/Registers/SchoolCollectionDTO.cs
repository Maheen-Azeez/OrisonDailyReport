using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrisonDailyReport.Shared.Entities.Registers
{
    public class SchoolCollectionDTO
    {
        public string? CompanyName { get; set; }
        public Decimal CounterCollection { get; set; }
        public Decimal OnlineCollection { get; set; }
    }
}
