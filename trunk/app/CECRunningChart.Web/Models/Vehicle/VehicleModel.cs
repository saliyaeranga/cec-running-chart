using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.Mvc;

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

        public List<FuelModel> AvailableFuel { get; set; }
        public List<LubricantModel> AvailableLubricants { get; set; }

        public IEnumerable<SelectListItem> GetAvailableFuelOptions()
        {
            List<SelectListItem> options = new List<SelectListItem>(AvailableFuel.Count + 1);
            options.Add(new SelectListItem() { Text = "- Select Fuel Type -", Value = "0", Selected = true });
            foreach (var item in AvailableFuel)
            {
                options.Add(new SelectListItem() { Text = item.FuelType, Value = item.Id.ToString() });
            }

            return options;
        }

        public IEnumerable<SelectListItem> GetAvailableLubricantOptions()
        {
            List<SelectListItem> options = new List<SelectListItem>(AvailableLubricants.Count + 1);
            options.Add(new SelectListItem() { Text = "- Select Lubricant Type -", Value = "0", Selected = true });
            foreach (var item in AvailableLubricants)
            {
                options.Add(new SelectListItem() { Text = item.LubricantType, Value = item.Id.ToString() });
            }

            return options;
        }
    }
}