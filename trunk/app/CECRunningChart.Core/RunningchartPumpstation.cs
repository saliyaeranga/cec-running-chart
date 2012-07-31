using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class RunningchartPumpstation
    {
        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("RunningchartId")]
        public int RunningchartId { get; set; }

        [XmlElementAttribute("PumpstationId")]
        public int PumpstationId { get; set; }

        [XmlElementAttribute("Amount")]
        public decimal Amount { get; set; }
    }
}
