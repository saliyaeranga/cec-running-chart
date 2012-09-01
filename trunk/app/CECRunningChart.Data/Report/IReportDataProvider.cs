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
        DataSet GetDriverTimeSheetReport(string driverName);
        DataSet GetFuelAndLubricantReport(DateTime startDate, DateTime endDate, int pumpstationId);
        DataSet GetVehicleMachineRegisterReport(DateTime startDate, DateTime endDate);
        DataSet GetHireBillReport(DateTime startDate, DateTime endDate, int projectId);
        DataSet GetHireBillPrivateReport(DateTime startDate, DateTime endDate, int vehicleId, out DataSet pumpStationDataSet, out DataSet lubricantsDataSet);
    }
}
