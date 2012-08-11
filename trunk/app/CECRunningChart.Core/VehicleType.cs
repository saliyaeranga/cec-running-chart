using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class VehicleType
    {
        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("VehicleType")]
        public string VehicleTypeName { get; set; }
    }
}
