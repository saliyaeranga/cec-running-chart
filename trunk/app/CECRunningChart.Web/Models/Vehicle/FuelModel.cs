using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CECRunningChart.Web.Models.Vehicle
{
    public class FuelModel
    {
        #region Public Prperties

        public int Id { get; set; }

        [DisplayName("Fuel Type")]
        [Required(ErrorMessage = "Fuel name is required.")]
        [MaxLength(200, ErrorMessage = "Fuel name can not have more than 200 characters")]
        public string FuelType { get; set; }

        [DisplayName("Rate")]
        [Required(ErrorMessage = "Fuel rate is required.")]
        [DataType(DataType.Currency)]
        public decimal FuelRate { get; set; }

        #endregion
    }
}