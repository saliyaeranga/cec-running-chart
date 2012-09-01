using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CECRunningChart.Core
{
    public class HireBillPrivateReport
    {
        public List<HireBillPrivateReportDetails> HireBillPrivateReportDetails { get; set; }
        public List<HireBillPrivateReportLubricant> HireBillPrivateReportLubricants { get; set; }
        public List<HireBillPrivateReportPumpstation> HireBillPrivateReportPumpstations { get; set; }
    }
}
