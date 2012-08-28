using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class VehicleMachineRegister
    {
        [XmlElementAttribute("VehicleId")]
        public int VehicleId { get; set; }

        [XmlElementAttribute("VehicleType")]
        public string VehicleType { get; set; }

        [XmlElementAttribute("VehicleNumber")]
        public string VehicleNumber { get; set; }

        [XmlElementAttribute("CompanyCode")]
        public string CompanyCode { get; set; }

        [XmlElementAttribute("VehicleLocation")]
        public string VehicleLocation { get; set; }
    }
}
