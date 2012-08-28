using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class HireBillReport
    {
        [XmlElementAttribute("RunningchartId")]
        public int RunningchartId { get; set; }

        [XmlElementAttribute("BillDate")]
        public DateTime BillDate { get; set; }

        [XmlElementAttribute("VehicleNumber")]
        public string VehicleNumber { get; set; }

        [XmlElementAttribute("CompanyCode")]
        public string CompanyCode { get; set; }

        [XmlElementAttribute("IsVehicle")]
        public bool IsVehicle { get; set; }

        [XmlElementAttribute("KmHrDone")]
        public string KmHrDone { get; set; }

        [XmlElementAttribute("VehicleRate")]
        public string VehicleRate { get; set; }

        [XmlElementAttribute("Amount")]
        public string Amount { get; set; }
    }
}
