using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CECRunningChart.Web.Models.Reports
{
    public class HireBillPrivateReportModel
    {
        public int RunningchartId { get; set; }
        public DateTime BillDate { get; set; }

        public List<HireBillPrivateReportDetailsModel> HireBillPrivateReportDetails { get; set; }
        public List<HireBillPrivateReportLubricantModel> HireBillPrivateReportLubricants { get; set; }
        public List<HireBillPrivateReportPumpstationModel> HireBillPrivateReportFuel { get; set; }

        public Dictionary<int, DateTime> RunningChartIds
        {
            get
            {
                Dictionary<int, DateTime> ids = new Dictionary<int, DateTime>();
                if (HireBillPrivateReportDetails != null && HireBillPrivateReportDetails.Count > 0)
                {
                    foreach (var item in HireBillPrivateReportDetails)
                    {
                        if (!ids.Keys.Contains(item.RunningchartId))
                        {
                            ids.Add(item.RunningchartId, item.BillDate);
                        }
                    }
                }

                return ids;
            }
        }

        /*
        public string BillDate { get; set; }
        public string ProjectLocation { get; set; }
        public string RunningchartId { get; set; }
        public string WorkDone { get; set; }
        public string HireAmount { get; set; }

        public string FuelPumpStation { get; set; }
        public string FuelQty { get; set; }
        public string FuelRate { get; set; }
        public string FuelAmount { get; set; }

        public string LubricantPumpStation { get; set; }
        public string LubricantQty { get; set; }
        public string LubricantRate { get; set; }
        public string LubricantAmount { get; set; }
         * 
        */
    }

    public class HireBillPrivateReportDetailsModel
    {
        public int RunningchartId { get; set; }
        public DateTime BillDate { get; set; }
        public string ProjectLocation { get; set; }
        public int VehicleRate { get; set; }
        public decimal FuelUsageOfDay { get; set; } //todo: float
        public decimal KmHrDone { get; set; }
        public decimal HireAmount { get; set; }
    }

    public class HireBillPrivateReportLubricantModel
    {
        public int Id { get; set; }
        public int RunningchartId { get; set; }
        public int PumpstationId { get; set; }
        public int LubricantTypeId { get; set; }
        public decimal LubricantRate { get; set; }
        public decimal Amount { get; set; }
        public int VehicleId { get; set; }
        public DateTime BillDate { get; set; }
        public string PumpstationName { get; set; }
        public string LubricantType { get; set; }
    }

    public class HireBillPrivateReportPumpstationModel
    {
        public int Id { get; set; }
        public int RunningchartId { get; set; }
        public int PumpstationId { get; set; }
        public decimal Amount { get; set; }
        public int VehicleId { get; set; }
        public DateTime BillDate { get; set; }
        public string PumpstationName { get; set; }
        public decimal FuelRate { get; set; }
    }
}