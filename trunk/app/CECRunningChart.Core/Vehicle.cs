using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class Vehicle
    {
        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Vehicle registred number
        /// </summary>
        [XmlElementAttribute("VehicleNumber")]
        public string VehicleNumber { get; set; }

        /// <summary>
        /// Vehicle category id
        /// </summary>
        [XmlElementAttribute("VehicleType")]
        public string VehicleType { get; set; } // TODO: rename to VehicleTypeId

        /// <summary>
        /// Vehicle category name
        /// </summary>
        public string VehicleTypeName { get; set; }

        /// <summary>
        /// Current rate (Km/L or Hrs/L) of the vehicle/machine
        /// </summary>
        public string FuelRate { get; set; }

        public string ActualFuelRate { get; set; } //TODO: Is this calculated or?

        /// <summary>
        /// Fuel type petrol or desl- TODO
        /// </summary>
        public string FuelType { get; set; }

        public string LubricantType { get; set; }

        /// <summary>
        /// Is the vehicle/machine hired by CEC
        /// </summary>
        public bool IsHiredVehicle { get; set; }

        /// <summary>
        /// If hired, hire rate in Rs
        /// </summary>
        public decimal HireRate { get; set; }

        /// <summary>
        /// Vehicle owner's name of hired vehicles
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Allocated driver for vehicle/machine
        /// </summary>
        public string DriverOperatorName { get; set; }

        /// <summary>
        /// Unique code supplied by the company for each vehicle/machine
        /// </summary>
        public string CompanyCode { get; set; }

        [XmlElementAttribute("Description")]
        public string Description { get; set; }

        [XmlElementAttribute("Status")]
        public bool Status { get; set; }
    }
}
