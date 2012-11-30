using System;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class WorkDoneReport
    {
        [XmlElementAttribute("RunningchartId")]
        public int RunningchartId { get; set; }

        [XmlElementAttribute("BillDate")]
        public DateTime BillDate { get; set; }

        [XmlElementAttribute("DriverName")]
        public string DriverName { get; set; }

        [XmlElementAttribute("WorkDone")]
        public decimal WorkDone { get; set; }

        [XmlElementAttribute("FuelUsageOfDay")]
        public decimal FuelUsageOfDay { get; set; }

        [XmlElementAttribute("ProjectLocation")]
        public string ProjectLocation { get; set; }
    }
}
