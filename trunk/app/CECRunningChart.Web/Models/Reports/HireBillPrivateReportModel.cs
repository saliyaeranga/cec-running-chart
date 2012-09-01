using System;
using System.Collections.Generic;
using System.Linq;

namespace CECRunningChart.Web.Models.Reports
{
    public class HireBillPrivateReportModel
    {
        #region Public Members

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

        #endregion
    }

    public class HireBillPrivateReportDetailsModel
    {
        #region Public Members

        public int RunningchartId { get; set; }
        public DateTime BillDate { get; set; }
        public string ProjectLocation { get; set; }
        public int VehicleRate { get; set; }
        public decimal FuelUsageOfDay { get; set; }
        public decimal KmHrDone { get; set; }
        public decimal HireAmount { get; set; }

        #endregion
    }

    public class HireBillPrivateReportLubricantModel
    {
        #region Public Members

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

        #endregion
    }

    public class HireBillPrivateReportPumpstationModel
    {
        #region Public Members

        public int Id { get; set; }
        public int RunningchartId { get; set; }
        public int PumpstationId { get; set; }
        public decimal Amount { get; set; }
        public int VehicleId { get; set; }
        public DateTime BillDate { get; set; }
        public string PumpstationName { get; set; }
        public decimal FuelRate { get; set; }

        #endregion
    }
}