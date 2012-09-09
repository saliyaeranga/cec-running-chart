using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CECRunningChart.Data.Runningchart;

namespace CECRunningChart.Services.Runningchart
{
    public class RunningchartService : IRunningchartService
    {
        private IRunningchartDataProvider dataProvider;

        public RunningchartService()
        {
            dataProvider = new RunningchartDataProvider();
        }

        public int GetNextRunningchartId()
        {
            return dataProvider.GetNextRunningchartId();
        }

        public int AddRunningchart(Core.Runningchart runningChart)
        {
            return dataProvider.AddRunningchart(runningChart);
        }

        public List<Core.Runningchart> GetNonePaarovedRunningCharts()
        {
            var chartData = dataProvider.GetNoneApprovedRunningCharts();
            return ConversionHelper.ConvertToList<Core.Runningchart>(chartData);
        }

        public List<Core.Runningchart> GetOperatorNoneApprovedRunningcharts(int operatorUserId)
        {
            var chartData = dataProvider.GetOperatorNoneApprovedRunningcharts(operatorUserId);
            return ConversionHelper.ConvertToList<Core.Runningchart>(chartData);
        }

        public Core.Runningchart GetRunningChart(int chartId)
        {
            Core.Runningchart runningchart = new Core.Runningchart();
            var runningChartDs = dataProvider.GetRunningChart(chartId);

            runningchart = ConversionHelper.ConvertToObject<Core.Runningchart>(runningChartDs.Tables["Runningchart"].Rows[0]);
            runningchart.RunningchartDetails = ConversionHelper.ConvertToList<Core.RunningchartDetails>(runningChartDs.Tables["RunningchartDetails"]);
            runningchart.RunningchartLubricants = ConversionHelper.ConvertToList<Core.RunningchartLubricant>(runningChartDs.Tables["RunningchartLubricants"]);
            runningchart.RunningchartPumpstation = ConversionHelper.ConvertToList<Core.RunningchartPumpstation>(runningChartDs.Tables["RunningchartPumpstation"]);

            return runningchart;
        }

        public void ApproveRunningChart(int runningChartId, int approvedBy)
        {
            dataProvider.ApproveRunningChart(runningChartId, approvedBy, DateTime.Now);
        }
    }
}
