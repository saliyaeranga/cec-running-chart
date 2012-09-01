using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class HireBillPrivateReportPumpstation
    {
        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("RunningchartId")]
        public int RunningchartId { get; set; }

        [XmlElementAttribute("PumpstationId")]
        public int PumpstationId { get; set; }

        [XmlElementAttribute("Amount")]
        public decimal Amount { get; set; }

        [XmlElementAttribute("VehicleId")]
        public int VehicleId { get; set; }

        [XmlElementAttribute("BillDate")]
        public DateTime BillDate { get; set; }

        [XmlElementAttribute("PumpstationName")]
        public string PumpstationName { get; set; }

        [XmlElementAttribute("FuelRate")]
        public decimal FuelRate { get; set; }
    }
}
