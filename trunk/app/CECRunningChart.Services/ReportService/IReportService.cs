using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CECRunningChart.Core;

namespace CECRunningChart.Services.ReportService
{
    public interface IReportService
    {
        List<FuelConsumptionReport> GetFuelConsumptionReport(DateTime startDate, DateTime endDate);
        List<HiredVehicleFuelReport> GetHiredVehicleFuelReport(DateTime startDate, DateTime endDate);
        List<DriverOperatorTimeSheet> GetDriverTimeSheetReport(string driverName);
    }
}
