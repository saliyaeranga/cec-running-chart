using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CECRunningChart.Data.Report
{
    public interface IReportDataProvider
    {
        DataSet GetFuelConsumptionReport(DateTime startDate, DateTime endDate);
        DataSet GetHiredVehicleFuelReport(DateTime startDate, DateTime endDate);
    }
}
