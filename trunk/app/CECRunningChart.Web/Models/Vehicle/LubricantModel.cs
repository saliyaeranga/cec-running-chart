using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CECRunningChart.Web.Models.Vehicle
{
    public class LubricantModel
    {
        #region Public Properties

        public int Id { get; set; }

        [DisplayName("Lubricant Type")]
        [Required(ErrorMessage = "Lubricant name is required.")]
        [MaxLength(200, ErrorMessage = "Lubricant name can not have more than 200 characters")]
        public string LubricantType { get; set; }

        [DisplayName("Rate")]
        [Required(ErrorMessage = "Lubricant rate is required.")]
        [DataType(DataType.Currency)]
        public decimal LubricantRate { get; set; }

        #endregion
    }
}