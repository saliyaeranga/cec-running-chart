using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CECRunningChart.Core;
using CECRunningChart.Data.Report;

namespace CECRunningChart.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly IReportDataProvider reportDataProvider;

        public ReportService()
        {
            reportDataProvider = new ReportDataProvider();
        }

        public List<FuelConsumptionReport> GetFuelConsumptionReport(DateTime startDate, DateTime endDate)
        {
            var reportData = reportDataProvider.GetFuelConsumptionReport(startDate, endDate);
            return ConversionHelper.ConvertToList<FuelConsumptionReport>(reportData);
        }

        public List<HiredVehicleFuelReport> GetHiredVehicleFuelReport(DateTime startDate, DateTime endDate)
        {
            var reportData = reportDataProvider.GetHiredVehicleFuelReport(startDate, endDate);
            return ConversionHelper.ConvertToList<HiredVehicleFuelReport>(reportData);
        }

        public List<DriverOperatorTimeSheet> GetDriverTimeSheetReport(string driverName)
        {
            var reportData = reportDataProvider.GetDriverTimeSheetReport(driverName);
            return ConversionHelper.ConvertToList<DriverOperatorTimeSheet>(reportData);
        }

        public List<FuelAndLubricantReport> GetFuelAndLubricantReport(DateTime startDate, DateTime endDate, int pumpstationId)
        {
            var reportData = reportDataProvider.GetFuelAndLubricantReport(startDate, endDate, pumpstationId);
            return ConversionHelper.ConvertToList<FuelAndLubricantReport>(reportData);
        }

    }
}
