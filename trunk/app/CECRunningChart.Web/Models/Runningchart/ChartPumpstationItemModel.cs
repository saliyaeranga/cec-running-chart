using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CECRunningChart.Web.Models.Pumpstation;

namespace CECRunningChart.Web.Models.Runningchart
{
    public class ChartPumpstationItemModel
    {
        //public int PumpstationId { get; set; }
        //public string PumpStationName { get; set; }
        public int PumpAmount { get; set; }

        public int SelectedPumpstationId { get; set; }
        public bool IsRemoving { get; set; }
    }
}