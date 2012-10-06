using System;
using System.Collections.Generic;
using CECRunningChart.Core;

namespace CECRunningChart.Services.ReportService
{
    public interface IReportService
    {
        #region Service Members

        List<FuelConsumptionReport> GetFuelConsumptionReport(DateTime startDate, DateTime endDate);
        List<HiredVehicleFuelReport> GetHiredVehicleFuelReport(DateTime startDate, DateTime endDate);
        List<DriverOperatorTimeSheet> GetDriverTimeSheetReport(string driverName, DateTime startDate, DateTime endDate);
        List<string> GetDriverNames();
        List<FuelAndLubricantReport> GetFuelAndLubricantReport(DateTime startDate, DateTime endDate, int pumpstationId);
        List<VehicleMachineRegister> GetVehicleMachineRegisterReport(DateTime startDate, DateTime endDate);
        List<HireBillReport> GetHireBillReport(DateTime startDate, DateTime endDate, int projectId);
        HireBillPrivateReport GetHireBillPrivateReport(DateTime startDate, DateTime endDate, int vehicleId);

        #endregion
    }
}
