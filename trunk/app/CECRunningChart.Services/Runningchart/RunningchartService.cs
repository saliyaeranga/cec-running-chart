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

        public List<Core.Runningchart> GetLatestRunningCharts()
        {
            var chartData = dataProvider.GetLatestRunningCharts();
            return ConversionHelper.ConvertToList<Core.Runningchart>(chartData);
        }
    }
}
