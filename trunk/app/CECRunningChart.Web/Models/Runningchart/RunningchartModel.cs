using System;
using System.Collections.Generic;
using CECRunningChart.Web.Models.Vehicle;
using System.Web.Mvc;
using System.Linq;
using CECRunningChart.Web.Models.Project;
using CECRunningChart.Web.Models.Pumpstation;

namespace CECRunningChart.Web.Models.Runningchart
{
    public class RunningchartModel
    {
        public int RunningchartId { get; set; }
        public string BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        public string DriverName { get; set; }

        /// <summary>
        /// Gets or sets the selected vehicle number for this running chart
        /// </summary>
        public string SelectedVehicleNo { get; set; }

        public int FuelLeftBegningOfDay { get; set; }

        public int FuelLeftEndOfDay { get; set; }

        public int FuelUsageOfDay { get; set; }

        public string DailyNote { get; set; }

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
        public int SelectedVehicleId { get; set; }

        /// <summary>
        /// Gets or sets the pumpstations selected by the user
        /// </summary>
        public List<ChartPumpstationItemModel> SelectedPumpstations { get; set; }

        /// <summary>
        /// Gets or sets the chart items selected by the user
        /// </summary>
        public List<ChartItemModel> SelectedChartItems { get; set; }

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
    }
}