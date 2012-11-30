using System;
using System.Collections.Generic;
using System.Data;
using CECRunningChart.Core;
using CECRunningChart.Data.Report;

namespace CECRunningChart.Services.ReportService
{
    public class ReportService : IReportService
    {
        #region Private Members

        private readonly IReportDataProvider reportDataProvider;

        #endregion

        #region Constructor

        public ReportService()
        {
            reportDataProvider = new ReportDataProvider();
        }

        #endregion

        #region Public Methods

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

        public List<DriverOperatorTimeSheet> GetDriverTimeSheetReport(string driverName, DateTime startDate, DateTime endDate)
        {
            var reportData = reportDataProvider.GetDriverTimeSheetReport(driverName, startDate, endDate);
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

        public List<WorkDoneReport> GetWorkDoneReport(DateTime startDate, DateTime endDate, int vehicleId)
        {
            var reportData = reportDataProvider.GetWorkDoneReport(startDate, endDate, vehicleId);
            return ConversionHelper.ConvertToList<WorkDoneReport>(reportData);
        }

        public List<string> GetDriverNames()
        {
            var data = reportDataProvider.GetDriverNames();
            List<string> names = new List<string>(data.Tables[0].Rows.Count + 1)
            {
                "- SELECT -"
            };
            foreach (DataRow row in data.Tables[0].Rows)
            {
                names.Add(row[0].ToString());
            }
            return names;
        }

        #endregion
    }
}
