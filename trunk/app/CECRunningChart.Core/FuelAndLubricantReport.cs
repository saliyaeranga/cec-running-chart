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
        public float FuelQty { get; set; }

        [XmlElementAttribute("FuelRate")]
        public float FuelRate { get; set; }

        [XmlElementAttribute("LubricantType")]
        public string LubricantType { get; set; }

        [XmlElementAttribute("LubricantQty")]
        public float LubricantQty { get; set; }

        [XmlElementAttribute("LubricantRate")]
        public float LubricantRate { get; set; }
    }
}
