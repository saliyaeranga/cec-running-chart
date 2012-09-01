using System.Collections.Generic;

namespace CECRunningChart.Core
{
    public class HireBillPrivateReport
    {
        #region Public Members

        public List<HireBillPrivateReportDetails> HireBillPrivateReportDetails { get; set; }
        public List<HireBillPrivateReportLubricant> HireBillPrivateReportLubricants { get; set; }
        public List<HireBillPrivateReportPumpstation> HireBillPrivateReportPumpstations { get; set; }

        #endregion
    }
}
