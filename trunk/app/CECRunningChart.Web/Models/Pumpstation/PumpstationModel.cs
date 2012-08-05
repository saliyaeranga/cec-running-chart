using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CECRunningChart.Web.Models.Pumpstation
{
    public class PumpstationModel
    {
        public int Id { get; set; }

        [DisplayName("Pumpstation Name")]
        [MaxLength(200, ErrorMessage = "Pumpstation name can not have more than 200 characters")]
        public string PumpStationName { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }
    }
}