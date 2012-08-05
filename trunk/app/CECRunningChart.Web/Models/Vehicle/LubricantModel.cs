using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CECRunningChart.Web.Models.Vehicle
{
    public class LubricantModel
    {
        #region Public Properties

        public int Id { get; set; }

        [DisplayName("Lubricant Type")]
        public string LubricantType { get; set; }

        [DisplayName("Rate")]
        [Required(ErrorMessage = "Lubricant rate is required.")]
        [DataType(DataType.Currency)]
        public decimal LubricantRate { get; set; }

        #endregion
    }
}