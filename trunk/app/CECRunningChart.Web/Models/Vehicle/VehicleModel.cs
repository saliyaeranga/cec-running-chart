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

        [DisplayName("Vehicle / Machine Type")]
        [MaxLength(100)]
        public string VehicleType { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Is Active Vehicle / Machine")]
        public bool Status { get; set; }
    }
}