using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CECRunningChart.Core;
using CECRunningChart.Data.Report;
using System.Data;

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

        public List<VehicleMachineRegister> GetVehicleMachineRegisterReport(DateTime startDate, DateTime endDate)
        {
            var reportData = reportDataProvider.GetVehicleMachineRegisterReport(startDate, endDate);
            return ConversionHelper.ConvertToList<VehicleMachineRegister>(reportData);
        }

        public List<HireBillReport> GetHireBillReport(DateTime startDate, DateTime endDate, int projectId)
        {
            var reportData = reportDataProvider.GetHireBillReport(startDate, endDate, projectId);
            return ConversionHelper.ConvertToList<HireBillReport>(reportData);
        }

        public HireBillPrivateReport GetHireBillPrivateReport(DateTime startDate, DateTime endDate, int vehicleId)
        {
            DataSet pumpStationDataSet;
            DataSet lubricantsDataSet;
            DataSet detailsDataSet = reportDataProvider.GetHireBillPrivateReport(startDate, endDate, vehicleId,
                out pumpStationDataSet, out lubricantsDataSet);

            var detailList = ConversionHelper.ConvertToList<HireBillPrivateReportDetails>(detailsDataSet);
            var lubricantList = ConversionHelper.ConvertToList<HireBillPrivateReportLubricant>(lubricantsDataSet);
            var pumpStationList = ConversionHelper.ConvertToList<HireBillPrivateReportPumpstation>(pumpStationDataSet);

            HireBillPrivateReport reportData = new HireBillPrivateReport()
            {
                HireBillPrivateReportDetails = detailList,
                HireBillPrivateReportLubricants = lubricantList,
                HireBillPrivateReportPumpstations = pumpStationList
            };

            return reportData;
        }

    }
}
