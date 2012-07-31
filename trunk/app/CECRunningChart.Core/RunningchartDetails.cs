using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class RunningchartDetails
    {
        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("RunningchartId")]
        public int RunningchartId { get; set; }

        [XmlElementAttribute("StartTime")]
        public DateTime StartTime { get; set; }

        [XmlElementAttribute("EndTime")]
        public DateTime EndTime { get; set; }

        [XmlElementAttribute("TimeDifference")]
        public string TimeDifference { get; set; }

        [XmlElementAttribute("StartMeter")]
        public string StartMeter { get; set; }

        [XmlElementAttribute("EndMeter")]
        public string EndMeter { get; set; }

        [XmlElementAttribute("MeterDifference")]
        public string MeterDifference { get; set; }

        [XmlElementAttribute("ProjectId")]
        public int ProjectId { get; set; }

        [XmlElementAttribute("ProjectManagerName")]
        public string ProjectManagerName { get; set; }
    }
}
