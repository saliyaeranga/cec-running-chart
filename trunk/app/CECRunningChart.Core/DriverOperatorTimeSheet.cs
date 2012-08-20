using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class DriverOperatorTimeSheet
    {
        #region Public Members

        [XmlElementAttribute("RunningchartId")]
        public int RunningchartId { get; set; }

        [XmlElementAttribute("DriverOperatorName")]
        public string DriverOperatorName { get; set; }

        [XmlElementAttribute("BillDate")]
        public DateTime BillDate { get; set; }

        [XmlElementAttribute("VehicleNumber")]
        public string VehicleNumber { get; set; }

        [XmlElementAttribute("IsVehicle")]
        public bool IsVehicle { get; set; }

        [XmlElementAttribute("InTime")]
        public DateTime InTime { get; set; }

        [XmlElementAttribute("OutTime")]
        public DateTime OutTime { get; set; }
        
        [XmlElementAttribute("WorkDone")]
        public int WorkDone { get; set; }

        [XmlElementAttribute("OTHours")]
        public float OTHours { get; set; }

        #endregion
    }
}
