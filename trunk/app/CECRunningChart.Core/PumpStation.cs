using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class PumpStation
    {
        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("PumpStationName")]
        public string PumpStationName { get; set; }

        [XmlElementAttribute("Description")]
        public string Description { get; set; }
    }
}
