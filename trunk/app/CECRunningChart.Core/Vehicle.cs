using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class Vehicle
    {
        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("VehicleNumber")]
        public string VehicleNumber { get; set; }

        [XmlElementAttribute("VehicleType")]
        public string VehicleType { get; set; }

        public string FuelUsage { get; set; } //rate

        public string FuelType { get; set; }

        [XmlElementAttribute("Description")]
        public string Description { get; set; }

        [XmlElementAttribute("Status")]
        public bool Status { get; set; }
    }
}
