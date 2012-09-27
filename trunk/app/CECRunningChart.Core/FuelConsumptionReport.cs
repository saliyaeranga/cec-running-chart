using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class FuelConsumptionReport
    {
        #region Public Members

        [XmlElementAttribute("VehicleId")]
        public int VehicleId { get; set; }

        [XmlElementAttribute("VehicleNumber")]
        public string VehicleNumber { get; set; }

        [XmlElementAttribute("IsVehicle")]
        public bool IsVehicle { get; set; }

        [XmlElementAttribute("DriverOperatorName")]
        public string DriverOperatorName { get; set; }

        [XmlElementAttribute("KmHrDone")]
        public int KmHrDone { get; set; }

        [XmlElementAttribute("TotalFuelUsage")]
        public decimal TotalFuelUsage { get; set; }

        [XmlElementAttribute("VehicleRate")]
        public decimal VehicleRate { get; set; }

        [XmlElementAttribute("ActualRate")]
        public decimal ActualRate { get; set; }

        #endregion
    }
}
