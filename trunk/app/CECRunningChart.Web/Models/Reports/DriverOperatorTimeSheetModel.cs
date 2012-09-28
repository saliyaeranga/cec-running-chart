using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CECRunningChart.Web.Models.Reports
{
    public class DriverOperatorTimeSheetModel
    {
        #region Public Members

        public int RunningchartId { get; set; }
        public string DriverOperatorName { get; set; }
        public DateTime BillDate { get; set; }
        public string VehicleNumber { get; set; }
        public bool IsVehicle { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public decimal WorkDone { get; set; }
        public decimal OTHours { get; set; }

        #endregion
    }
}