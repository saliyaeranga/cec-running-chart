﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CECRunningChart.Web.Models.Reports
{
    public class HiredVehicleFuelReportModel
    {
        #region Public Members

        public int VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public bool IsVehicle { get; set; }
        public string DriverOperatorName { get; set; }
        public string OwnerName { get; set; }
        public int KmHrDone { get; set; }
        public int FuelDrawn { get; set; }

        #endregion
    }
}