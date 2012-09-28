using System;
using System.Collections.Generic;
using CECRunningChart.Web.Models.Pumpstation;
using System.Web.Mvc;
using System.Linq;

namespace CECRunningChart.Web.Models.Reports
{
    public class FuelAndLubricantReportModel
    {
        public int RunningchartId { get; set; }
        public DateTime BillDate { get; set; }
        public int VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public bool IsVehicle { get; set; }
        public string DriverOperatorName { get; set; }
        public bool IsHiredVehicle { get; set; }
        public string FuelType { get; set; }
        public decimal FuelQty { get; set; }
        public decimal FuelRate { get; set; }
        public string LubricantType { get; set; }
        public decimal LubricantQty { get; set; }
        public decimal LubricantRate { get; set; }
    }
}