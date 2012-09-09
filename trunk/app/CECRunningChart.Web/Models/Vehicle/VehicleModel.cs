using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CECRunningChart.Web.Models.Vehicle
{
    public class VehicleModel
    {
        #region Public Members

        public int Id { get; set; }

        [DisplayName("Vehicle / Machine #")]
        [Required(ErrorMessage = "Vehicle / Machine number is required")]
        [MaxLength(50, ErrorMessage = "Vehicle / Machine number can not have more than 50 characters")]
        public string VehicleNumber { get; set; }

        [DisplayName("Company Code")]
        [Required(ErrorMessage = "Company Code is required")]
        [MaxLength(50, ErrorMessage = "Company Code can not have more than 50 characters")]
        public string CompanyCode { get; set; }

        [Required(ErrorMessage = "Vehicle Type is required")]
        public int VehicleTypeId { get; set; }

        [DisplayName("Vehicle Type")]
        public string VehicleTypeName { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Driver/Operator Name")]
        [Required(ErrorMessage = "Driver/Operator Name is required")]
        [MaxLength(200, ErrorMessage = "Driver/Operator Name can not have more than 200 characters")]
        public string DriverOperatorName { get; set; }

        [DisplayName("Fuel Usage (Km/L)")]
        [Required(ErrorMessage = "Fuel Usage is required")]
        public float FuelUsage { get; set; }

        [Required(ErrorMessage = "Fuel Type is required")]
        public int FuelTypeId { get; set; }

        [DisplayName("Fuel Type")]
        public string FuelTypeName { get; set; }

        [Required(ErrorMessage = "Lubricant Type is required")]
        public int LubricantTypeId { get; set; }

        [DisplayName("Lubricant Type")]
        public string LubricantTypeName { get; set; }

        [DisplayName("Is Hired Vehicle")]
        public bool IsHiredVehicle { get; set; }

        [DisplayName("Hire Rate")]
        public decimal HireRate { get; set; } //TODO

        [DisplayName("Owner Name")]
        [MaxLength(200, ErrorMessage = "Owner Name can not have more than 200 characters")]
        public string OwnerName { get; set; }

        [DisplayName("Vehicle / Machine")]
        public bool IsVehicle { get; set; }

        public int VehicleOrMachine { get; set; }

        [DisplayName("Is Active Vehicle / Machine")]
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets all available fuel types
        /// </summary>
        public List<FuelModel> AvailableFuel { get; set; }

        /// <summary>
        /// Gets or sets all available lubricant types
        /// </summary>
        public List<LubricantModel> AvailableLubricants { get; set; }

        /// <summary>
        /// Gets or sets all available vehicle types
        /// </summary>
        public List<VehicleTypeModel> AvailableVehicleTypes { get; set; }

        #endregion

        #region Public Methods

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

        public IEnumerable<SelectListItem> GetAvailableVehicleTypeOptions()
        {
            List<SelectListItem> options = new List<SelectListItem>(AvailableVehicleTypes.Count + 1);
            options.Add(new SelectListItem() { Text = "- Select Vehicle Type -", Value = "0", Selected = true });
            foreach (var item in AvailableVehicleTypes)
            {
                options.Add(new SelectListItem() { Text = item.VehicleTypeName, Value = item.Id.ToString() });
            }

            return options;
        }

        #endregion
    }
}