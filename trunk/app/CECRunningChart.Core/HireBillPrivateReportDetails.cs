using System;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class HireBillPrivateReportDetails
    {
        #region Public Members

        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("BillDate")]
        public DateTime BillDate { get; set; }

        [XmlElementAttribute("ProjectLocation")]
        public string ProjectLocation { get; set; }

        [XmlElementAttribute("VehicleRate")]
        public int VehicleRate { get; set; }

        [XmlElementAttribute("FuelUsageOfDay")]
        public decimal FuelUsageOfDay { get; set; }

        [XmlElementAttribute("KmHrDone")]
        public decimal KmHrDone { get; set; }

        [XmlElementAttribute("HireAmount")]
        public decimal HireAmount { get; set; }

        #endregion
    }
}
