using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class RunningchartLubricant
    {
        #region Public Properties

        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("RunningchartId")]
        public int RunningchartId { get; set; }

        [XmlElementAttribute("PumpstationId")]
        public int PumpstationId { get; set; }

        [XmlElementAttribute("LubricantTypeId")]
        public int LubricantTypeId { get; set; }

        [XmlElementAttribute("Amount")]
        public decimal Amount { get; set; }

        #endregion
    }
}
