using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CECRunningChart.Web.Models.Reports
{
    public class FuelConsumptionReportModel
    {
        #region Public Members

        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        public int VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public bool IsVehicle { get; set; }
        public string DriverOperatorName { get; set; }
        public decimal KmHrDone { get; set; }
        public decimal TotalFuelUsage { get; set; }
        public decimal VehicleRate { get; set; }
        public decimal ActualRate { get; set; }

        #endregion
    }
}