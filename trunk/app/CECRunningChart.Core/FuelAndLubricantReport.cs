using System;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class FuelAndLubricantReport
    {
        [XmlElementAttribute("RunningchartId")]
        public int RunningchartId { get; set; }

        [XmlElementAttribute("BillDate")]
        public DateTime BillDate { get; set; }

        [XmlElementAttribute("VehicleId")]
        public int VehicleId { get; set; }

        [XmlElementAttribute("VehicleNumber")]
        public string VehicleNumber { get; set; }

        [XmlElementAttribute("IsVehicle")]
        public bool IsVehicle { get; set; }

        [XmlElementAttribute("DriverOperatorName")]
        public string DriverOperatorName { get; set; }

        [XmlElementAttribute("IsHiredVehicle")]
        public bool IsHiredVehicle { get; set; }

        [XmlElementAttribute("FuelType")]
        public string FuelType { get; set; }

        [XmlElementAttribute("FuelQty")]
        public decimal FuelQty { get; set; }

        [XmlElementAttribute("FuelRate")]
        public decimal FuelRate { get; set; }

        [XmlElementAttribute("LubricantType")]
        public string LubricantType { get; set; }

        [XmlElementAttribute("LubricantQty")]
        public decimal LubricantQty { get; set; }

        [XmlElementAttribute("LubricantRate")]
        public decimal LubricantRate { get; set; }
    }
}
