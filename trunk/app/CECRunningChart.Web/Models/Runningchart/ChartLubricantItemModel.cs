using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CECRunningChart.Web.Models.Runningchart
{
    public class ChartLubricantItemModel
    {
        public int SelectedPumpstationId { get; set; }
        public int SelectedLubricantTypeId { get; set; }
        public int PumpAmount { get; set; }
        public bool IsRemoving { get; set; }
    }
}