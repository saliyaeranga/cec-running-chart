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
        /// Unique code supplied by the company for each vehicle/machine
        /// </summary>
        [XmlElementAttribute("CompanyCode")]
        public string CompanyCode { get; set; }

        /// <summary>
        /// Vehicle category id
        /// </summary>
        [XmlElementAttribute("VehicleTypeId")]
        public int VehicleTypeId { get; set; }

        /// <summary>
        /// Vehicle category name
        /// </summary>
        [XmlElementAttribute("VehicleTypeName")]
        public string VehicleTypeName { get; set; }

        [XmlElementAttribute("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Allocated driver for vehicle/machine
        /// </summary>
        [XmlElementAttribute("DriverOperatorName")]
        public string DriverOperatorName { get; set; }

        /// <summary>
        /// Current rate (Km/L or Hrs/L) of the vehicle/machine
        /// </summary>
        [XmlElementAttribute("FuelUsage")]
        public string FuelUsage { get; set; }

        /// <summary>
        /// Fuel type id
        /// </summary>
        [XmlElementAttribute("FuelTypeId")]
        public int FuelType { get; set; }

        /// <summary>
        /// Name of the fuel type
        /// </summary>
        [XmlElementAttribute("FuelTypeName")]
        public string FuelTypeName { get; set; }

        [XmlElementAttribute("LubricantTypeId")]
        public int LubricantType { get; set; }

        [XmlElementAttribute("LubricantTypeName")]
        public string LubricantTypeName { get; set; }

        /// <summary>
        /// Is the vehicle/machine hired by CEC
        /// </summary>
        [XmlElementAttribute("IsHiredVehicle")]
        public bool IsHiredVehicle { get; set; }

        /// <summary>
        /// If hired, hire rate in Rs
        /// </summary>
        [XmlElementAttribute("HireRate")]
        public decimal HireRate { get; set; }

        /// <summary>
        /// Vehicle owner's name of hired vehicles
        /// </summary>
        [XmlElementAttribute("OwnerName")]
        public string OwnerName { get; set; }

        [XmlElementAttribute("IsVehicle")]
        public bool IsVehicle { get; set; }

        [XmlElementAttribute("Status")]
        public bool Status { get; set; }

        //public string ActualFuelRate { get; set; } //TODO: Is this calculated or?
    }
}
