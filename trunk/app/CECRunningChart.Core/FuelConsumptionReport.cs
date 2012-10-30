using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class FuelConsumptionReport
    {
        #region Public Members

        [XmlElementAttribute("RunningchartId")]
        public int RunningchartId { get; set; }

        [XmlElementAttribute("VehicleRate")]
        public decimal VehicleRate { get; set; }

        [XmlElementAttribute("VehicleId")]
        public int VehicleId { get; set; }

        [XmlElementAttribute("VehicleNumber")]
        public string VehicleNumber { get; set; }

        [XmlElementAttribute("IsVehicle")]
        public bool IsVehicle { get; set; }

        [XmlElementAttribute("DriverOperatorName")]
        public string DriverOperatorName { get; set; }

        [XmlElementAttribute("RdRunningchartId")]
        public int RdRunningchartId { get; set; }

        [XmlElementAttribute("MeterDifference")]
        public decimal MeterDifference { get; set; }

        [XmlElementAttribute("RpRunningchartId")]
        public int RpRunningchartId { get; set; }

        [XmlElementAttribute("PumpAmount")]
        public decimal PumpAmount { get; set; }

        //[XmlElementAttribute("ActualRate")]
        //public decimal ActualRate { get; set; }

        #endregion
    }
}
