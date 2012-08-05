using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class FuelType
    {
        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("FuelType")]
        public string FuelName { get; set; }

        [XmlElementAttribute("Rate")]
        public decimal FuelRate { get; set; }
    }
}
