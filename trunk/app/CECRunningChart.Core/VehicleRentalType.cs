﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class VehicleRentalType
    {
        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("RentalTypeName")]
        public string RentalTypeName { get; set; }
    }
}
