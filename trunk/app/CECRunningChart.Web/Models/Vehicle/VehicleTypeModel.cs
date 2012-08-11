using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CECRunningChart.Web.Models.Vehicle
{
    public class VehicleTypeModel
    {
        public int Id { get; set; }

        [DisplayName("Vehicle Type")]
        [Required(ErrorMessage = "Vehicle Type is required")]
        [MaxLength(500, ErrorMessage = "Vehicle Type can not have more than 500 characters")]
        public string VehicleTypeName { get; set; }
    }
}