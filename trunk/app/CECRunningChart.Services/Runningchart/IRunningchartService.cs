using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CECRunningChart.Services.Runningchart
{
    public interface IRunningchartService
    {
        int GetNextRunningchartId();
        int AddRunningchart(Core.Runningchart runningChart);
        List<Core.Runningchart> GetNoneApprovedRunningCharts();
        List<Core.Runningchart> GetOperatorNoneApprovedRunningcharts(int operatorUserId);
        List<Core.Runningchart> GetApprovedRunningCharts();
        List<Core.Runningchart> GetOperatorApprovedRunningcharts(int operatorUserId);
        Core.Runningchart GetRunningChart(int chartId);
        void ApproveRunningChart(int runningChartId, int approvedBy);
        decimal GetFuelLeftBegningOfDay(int vehicleId);
    }
}
