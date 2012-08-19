using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class HiredVehicleFuelReport
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

        [XmlElementAttribute("OwnerName")]
        public string OwnerName { get; set; }

        [XmlElementAttribute("KmHrDone")]
        public int KmHrDone { get; set; }

        [XmlElementAttribute("FuelDrawn")]
        public int FuelDrawn { get; set; }

        #endregion
    }
}
