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
        List<Core.Runningchart> GetLatestRunningCharts();
    }
}
