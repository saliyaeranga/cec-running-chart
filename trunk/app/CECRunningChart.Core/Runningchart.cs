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

        [XmlElementAttribute("VehicleRate")]
        public int VehicleRate { get; set; }

        [XmlElementAttribute("FuelLeftBegning")]
        public int FuelLeftBegning { get; set; }

        [XmlElementAttribute("FuelLeftEnd")]
        public int FuelLeftEnd { get; set; }

        [XmlElementAttribute("FuelUsageOfDay")]
        public int FuelUsageOfDay { get; set; }

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

        ///// <summary>
        ///// Indicates whether the associated vehicle is a vehicle or a machine.
        ///// true if it is a vehicle, false if it is a machine.
        ///// </summary>
        //[XmlElementAttribute("IsVehicle")]
        //public bool IsVehicle { get; set; }

        //TODO: Remove
        //[XmlElementAttribute("VehicleNumber")]
        //public string VehicleNumber { get; set; }


        //TODO: Add Runningchart modification history table

        //[XmlElementAttribute("Id")]
        //public string DayEndVehicleLocation { get; set; } // Where is the vehicle at the end of the day - Project.Location

        public List<RunningchartDetails> RunningchartDetails { get; set; }
        public List<RunningchartPumpstation> RunningchartPumpstation { get; set; }
    }
}
