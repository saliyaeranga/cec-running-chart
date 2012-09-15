using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class Runningchart
    {
        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("BillNumber")]
        public string BillNumber { get; set; }

        [XmlElementAttribute("BillDate")]
        public DateTime BillDate { get; set; }

        [XmlElementAttribute("DriverName")]
        public string DriverName { get; set; }

        [XmlElementAttribute("VehicleId")]
        public int VehicleId { get; set; }

        /// <summary>
        /// Fuel usage/consumption of the vehicle (i.e : L\KM)
        /// eg. 5 leters per Km
        /// </summary>
        [XmlElementAttribute("VehicleRate")]
        public decimal VehicleRate { get; set; }

        /// <summary>
        /// Hire rate of the vehicle (i.e : Rs/Km or Rs/Hr)
        /// eg. 100 ruppies per km or 100 ruppies per hour
        /// </summary>
        [XmlElementAttribute("VehicleHireRate")]
        public decimal VehicleHireRate { get; set; }

        /// <summary>
        /// Fuel rate of the vehicle (i.e Rs/L)
        /// eg. 150 ruppies per petral leter
        /// </summary>
        [XmlElementAttribute("FuelRate")]
        public decimal FuelRate { get; set; }

        [XmlElementAttribute("FuelLeftBegning")]
        public decimal FuelLeftBegning { get; set; }

        [XmlElementAttribute("FuelLeftEnd")]
        public decimal FuelLeftEnd { get; set; }

        [XmlElementAttribute("FuelUsageOfDay")]
        public decimal FuelUsageOfDay { get; set; }

        [XmlElementAttribute("DailyNote")]
        public string DailyNote { get; set; }

        [XmlElementAttribute("DayStartime")]
        public DateTime DayStartime { get; set; }

        [XmlElementAttribute("DayEndTime")]
        public DateTime DayEndTime { get; set; }

        [XmlElementAttribute("EnteredBy")]
        public int EnteredBy { get; set; }

        [XmlElementAttribute("IsApproved")]
        public bool IsApproved { get; set; }

        [XmlElementAttribute("ApprovedBy")]
        public int ApprovedBy { get; set; }

        [XmlElementAttribute("ApprovedDate")]
        public DateTime ApprovedDate { get; set; }

        //TODO: Add Runningchart modification history table

        public List<RunningchartDetails> RunningchartDetails { get; set; }
        public List<RunningchartPumpstation> RunningchartPumpstation { get; set; }
        public List<RunningchartLubricant> RunningchartLubricants { get; set; }
    }
}
