using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CECRunningChart.Web.Models.Project;
using CECRunningChart.Web.Models.Pumpstation;
using CECRunningChart.Web.Models.Vehicle;
using System.ComponentModel.DataAnnotations;

namespace CECRunningChart.Web.Models.Runningchart
{
    public class RunningchartModel
    {
        #region Public Properties

        public int RunningchartId { get; set; }

        [Required(ErrorMessage = "Bill number required")]
        public string BillNumber { get; set; }

        [Required(ErrorMessage = "Bill date required")]
        public DateTime BillDate { get; set; }

        [Required(ErrorMessage = "Driver name required")]
        public string DriverName { get; set; }

        [Required(ErrorMessage = "Fuel quantity required")]
        public int FuelLeftBegningOfDay { get; set; }

        [Required(ErrorMessage = "Fuel quantity required")]
        public int FuelLeftEndOfDay { get; set; }

        [Required(ErrorMessage = "Fuel quantity required")]
        public int FuelUsageOfDay { get; set; }

        public string DailyNote { get; set; }
        public DateTime DayStartime { get; set; }
        public DateTime DayEndTime { get; set; }
        public int EnteredBy { get; set; }
        public bool IsApproved { get; set; }
        public int ApprovedBy { get; set; }

        /// <summary>
        /// Gets or sets the available projects
        /// </summary>
        public List<ProjectModel> Projects { get; set; }

        /// <summary>
        /// Gets or sets the available vehicles
        /// </summary>
        public List<VehicleModel> Vehicles { get; set; }

        /// <summary>
        /// Gets or sets the available pumpstations
        /// </summary>
        public List<PumpstationModel> Pumpstations { get; set; }

        /// <summary>
        /// Gets or sets the vehicle id selected by the user
        /// </summary>
        [Required(ErrorMessage = "Please select vehicle id")]
        public int SelectedVehicleId { get; set; }

        /// <summary>
        /// Indicates whether the selected vehicle is a vehicle or a machine.
        /// true if it is a vehicle, false if it is a machine
        /// </summary>
        public bool isVehicle { get; set; }

        /// <summary>
        /// Gets or sets the pumpstations selected by the user
        /// </summary>
        public List<ChartPumpstationItemModel> SelectedPumpstations { get; set; }

        /// <summary>
        /// Gets or sets the lubricants selected by the user
        /// </summary>
        public List<ChartLubricantItemModel> SelectedLubricants { get; set; }

        /// <summary>
        /// Gets or sets the available lubricant types
        /// </summary>
        public List<LubricantModel> Lubricants { get; set; }

        /// <summary>
        /// Gets or sets the chart items selected by the user
        /// </summary>
        public List<ChartItemModel> SelectedChartItems { get; set; }

        /// <summary>
        /// Gets or sets the available vehicle rental types
        /// </summary>
        public List<VehicleRentalTypeModel> VehicleRentalTypes { get; set; }

        #endregion

        #region Public Methods

        public IEnumerable<SelectListItem> GetProjectOptions(int selectedProjectId)
        {
            List<SelectListItem> options = new List<SelectListItem>(Projects.Count + 1)
            {
                new SelectListItem(){ Text = "- SELECT -", Value = "0", Selected = selectedProjectId == 0}
            };
            var projects = from p in Projects
                               select new SelectListItem
                               {
                                   Text = p.ProjectName,
                                   Value = p.Id.ToString(),
                                   Selected = p.Id == selectedProjectId
                               };

            return options.Concat(projects.ToList());
        }

        public IEnumerable<SelectListItem> GetPumpstationOptions(int selectedPumpstationId)
        {
            List<SelectListItem> options = new List<SelectListItem>(Pumpstations.Count + 1)
            {
                new SelectListItem(){ Text = "- SELECT -", Value = "0", Selected = selectedPumpstationId == 0}
            };
            var pumpstations = from p in Pumpstations
                               select new SelectListItem
                               {
                                   Text = p.PumpStationName,
                                   Value = p.Id.ToString(),
                                   Selected = p.Id == selectedPumpstationId
                               };

            return options.Concat(pumpstations.ToList());
        }

        public IEnumerable<SelectListItem> GetLubricantOptions(int selectedLubricantId)
        {
            List<SelectListItem> options = new List<SelectListItem>(Pumpstations.Count + 1)
            {
                new SelectListItem(){ Text = "- SELECT -", Value = "0", Selected = selectedLubricantId == 0}
            };
            var lubricants = from l in Lubricants
                               select new SelectListItem
                               {
                                   Text = l.LubricantType,
                                   Value = l.Id.ToString(),
                                   Selected = l.Id == selectedLubricantId
                               };

            return options.Concat(lubricants.ToList());
        }

        public IEnumerable<SelectListItem> GetVehicleOptions()
        {
            List<SelectListItem> options = new List<SelectListItem>(Vehicles.Count + 1)
            {
                new SelectListItem(){ Text = "- SELECT -", Value = "0" }
            };
            var vehicles = from v in Vehicles
                               select new SelectListItem
                               {
                                   Text = v.VehicleNumber,
                                   Value = v.Id.ToString()
                               };

            return options.Concat(vehicles.ToList());
        }

        public IEnumerable<SelectListItem> GetRentalTypeOptions(int selectedRentalTypeId)
        {
            List<SelectListItem> options = new List<SelectListItem>(VehicleRentalTypes.Count + 1)
            {
                new SelectListItem(){ Text = "- SELECT -", Value = "0", Selected = selectedRentalTypeId == 0}
            };
            var rentals = from r in VehicleRentalTypes
                           select new SelectListItem
                           {
                               Text = r.RentalTypeName,
                               Value = r.Id.ToString(),
                               Selected = r.Id == selectedRentalTypeId
                           };

            return options.Concat(rentals.ToList());
        }

        #endregion
    }
}