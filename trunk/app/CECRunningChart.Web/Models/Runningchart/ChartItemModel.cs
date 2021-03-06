﻿using System.Collections.Generic;
using CECRunningChart.Web.Models.Project;

namespace CECRunningChart.Web.Models.Runningchart
{
    public class ChartItemModel
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string TimeDifference { get; set; } //todo: datatype
        public string StartMeter { get; set; }
        public string EndMeter { get; set; }
        public string MeterDifference { get; set; } //todo: datatype
        public float IdleHours { get; set; }
        public int SelectedProjectId { get; set; }
        public int SelectedRentalTypeId { get; set; }
        public string SelectedProjectManager { get; set; }
        public List<ProjectModel> Vehicles { get; set; } // To populate Projects dropdown
        public bool IsRemoving { get; set; }
    }
}