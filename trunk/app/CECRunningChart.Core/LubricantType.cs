using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class LubricantType
    {
        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("LubricantType")]
        public string LubricantName { get; set; }

        [XmlElementAttribute("Rate")]
        public decimal LubricantRate { get; set; }
    }
}
