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
        public decimal KmHrDone { get; set; }

        [XmlElementAttribute("VehicleHireRate")]
        public decimal VehicleHireRate { get; set; }

        [XmlElementAttribute("Amount")]
        public decimal Amount { get; set; }
    }
}
