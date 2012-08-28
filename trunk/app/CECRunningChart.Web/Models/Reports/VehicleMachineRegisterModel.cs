using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CECRunningChart.Web.Models.Reports
{
    public class VehicleMachineRegisterModel
    {
        public int VehicleId { get; set; }
        public string VehicleType { get; set; }
        public string VehicleNumber { get; set; }
        public string CompanyCode { get; set; }
        public string VehicleLocation { get; set; }
    }
}