using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CECRunningChart.Web.Models.Vehicle
{
    public class FuelModel
    {
        public int Id { get; set; }

        [DisplayName("Fuel Type")]
        public string FuelType { get; set; }

        [DisplayName("Rate")]
        [Required(ErrorMessage = "Fuel rate is required.")]
        [DataType(DataType.Currency)]
        public decimal FuelRate { get; set; }
    }
}