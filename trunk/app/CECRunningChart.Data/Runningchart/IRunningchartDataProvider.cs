using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CECRunningChart.Data.Runningchart
{
    public interface IRunningchartDataProvider
    {
        int GetNextRunningchartId();
        int AddRunningchart(Core.Runningchart runningChart);
        DataSet GetNoneApprovedRunningCharts();
        DataSet GetOperatorNoneApprovedRunningcharts(int operatorUserId);
        DataSet GetRunningChart(int chartId);
        void ApproveRunningChart(int runningChartId, int approvedBy, DateTime approvedDate);
        DataSet GetFuelLeftBegningOfDay(int vehicleId);
    }
}
