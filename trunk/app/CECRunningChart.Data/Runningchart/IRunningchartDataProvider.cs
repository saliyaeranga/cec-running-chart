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
        DataSet GetLatestRunningCharts();
    }
}
