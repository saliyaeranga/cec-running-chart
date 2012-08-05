using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CECRunningChart.Web.Models.Vehicle
{
    public class VehicleModel
    {
        public int Id { get; set; }

        [DisplayName("Vehicle / Machine #")]
        [Required(ErrorMessage = "Vehicle / Machine number is required")]
        [MaxLength(50, ErrorMessage = "Vehicle / Machine number can not have more than 50 characters")]
        public string VehicleNumber { get; set; }

        [DisplayName("Company Code")]
        public string CompanyCode { get; set; }

        public int VehicleTypeId { get; set; }

        [DisplayName("Vehicle Type")]
        public string VehicleTypeName { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Driver/Operator Name")]
        public string DriverOperatorName { get; set; }

        [DisplayName("Fuel Usage")]
        public string FuelUsage { get; set; }

        public int FuelType { get; set; }

        [DisplayName("Fuel Type")]
        public string FuelTypeName { get; set; }

        public int LubricantType { get; set; }

        [DisplayName("Lubricant Type")]
        public string LubricantTypeName { get; set; }

        [DisplayName("Is Hired Vehicle")]
        public bool IsHiredVehicle { get; set; }

        [DisplayName("Hire Rate")]
        public decimal HireRate { get; set; }

        [DisplayName("Owner Name")]
        public string OwnerName { get; set; }

        [DisplayName("Is Vehicle")]
        public bool IsVehicle { get; set; }

        [DisplayName("Is Active Vehicle / Machine")]
        public bool Status { get; set; }

        //[DisplayName("Vehicle / Machine Type")]
        //[MaxLength(100)]
        //public string VehicleType { get; set; }


    }
}