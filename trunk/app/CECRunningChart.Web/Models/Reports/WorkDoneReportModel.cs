using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CECRunningChart.Web.Models.Reports
{
    public class WorkDoneReportModel
    {
        public int RunningchartId { get; set; }
        public DateTime BillDate { get; set; }
        public string DriverName { get; set; }
        public decimal WorkDone { get; set; }
        public decimal FuelUsageOfDay { get; set; }
        public string ProjectLocation { get; set; }
    }
}