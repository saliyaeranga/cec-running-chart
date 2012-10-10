using System;
using System.Collections.Generic;
using CECRunningChart.Data.Runningchart;

namespace CECRunningChart.Services.Runningchart
{
    public class RunningchartService : IRunningchartService
    {
        #region Private Members

        private IRunningchartDataProvider dataProvider;

        #endregion

        #region Constructor

        public RunningchartService()
        {
            dataProvider = new RunningchartDataProvider();
        }

        #endregion

        public int GetNextRunningchartId()
        {
            return dataProvider.GetNextRunningchartId();
        }

        public int AddRunningchart(Core.Runningchart runningChart)
        {
            // TODO: Process fuel consumption data
            return dataProvider.AddRunningchart(runningChart);
        }

        public List<Core.Runningchart> GetNoneApprovedRunningCharts()
        {
            var chartData = dataProvider.GetNoneApprovedRunningCharts();
            return ConversionHelper.ConvertToList<Core.Runningchart>(chartData);
        }

        public List<Core.Runningchart> GetOperatorNoneApprovedRunningcharts(int operatorUserId)
        {
            var chartData = dataProvider.GetOperatorNoneApprovedRunningcharts(operatorUserId);
            return ConversionHelper.ConvertToList<Core.Runningchart>(chartData);
        }

        public List<Core.Runningchart> GetApprovedRunningCharts()
        {
            var chartData = dataProvider.GetApprovedRunningCharts();
            return ConversionHelper.ConvertToList<Core.Runningchart>(chartData);
        }

        public List<Core.Runningchart> GetOperatorApprovedRunningcharts(int operatorUserId)
        {
            var chartData = dataProvider.GetOperatorApprovedRunningcharts(operatorUserId);
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

        public decimal GetFuelLeftBegningOfDay(int vehicleId)
        {
            var data = dataProvider.GetFuelLeftBegningOfDay(vehicleId);
            decimal fuelLeft = decimal.Zero;
            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {
                var chartInfo = ConversionHelper.ConvertToObject<Core.Runningchart>(data.Tables[0].Rows[0]);
                fuelLeft = chartInfo.FuelLeftEnd;                
            }
            return fuelLeft;
        }

        public void DeleteRunningChart(int runningchartId)
        {
            dataProvider.DeleteRunningChart(runningchartId);
        }
    }
}
