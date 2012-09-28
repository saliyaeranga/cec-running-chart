using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CECRunningChart.Web.Models.Reports
{
    public class HireBillReportModel
    {
        public int RunningchartId { get; set; }
        public DateTime BillDate { get; set; }
        public string VehicleNumber { get; set; }
        public string CompanyCode { get; set; }
        public bool IsVehicle { get; set; }
        public decimal KmHrDone { get; set; }
        public decimal VehicleHireRate { get; set; }
        public decimal Amount { get; set; }
    }
}