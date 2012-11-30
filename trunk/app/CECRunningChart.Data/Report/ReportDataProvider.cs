using System;
using System.Data;

namespace CECRunningChart.Data.Report
{
    public class ReportDataProvider : BaseDataProvider, IReportDataProvider
    {
        #region IReportDataProvider Members

        public DataSet GetFuelConsumptionReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@StartDate", startDate);
                parameters.Add("@EndDate", endDate);
                return ExecuteDataSet("proc_RptFuelConsumptionReport", parameters);
                //return ExecuteDataSet("proc_FuelConsumptionReport", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetHiredVehicleFuelReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@StartDate", startDate);
                parameters.Add("@EndDate", endDate);
                return ExecuteDataSet("proc_RptHiredVehicleFuelReport", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetDriverTimeSheetReport(string driverName, DateTime startDate, DateTime endDate)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@DriverOperatorName", driverName);
                parameters.Add("@StartDate", startDate);
                parameters.Add("@EndDate", endDate);
                return ExecuteDataSet("proc_RptDriverOperatorTimeSheet", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetFuelAndLubricantReport(DateTime startDate, DateTime endDate, int pumpstationId)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@StartDate", startDate);
                parameters.Add("@EndDate", endDate);
                parameters.Add("@PumpstationId", pumpstationId);
                return ExecuteDataSet("proc_RptFuelLubricantReport", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetVehicleMachineRegisterReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@StartDate", startDate);
                parameters.Add("@EndDate", endDate);
                return ExecuteDataSet("proc_RptVehicleMachineRegisterReport", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetHireBillReport(DateTime startDate, DateTime endDate, int projectId)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@StartDate", startDate);
                parameters.Add("@EndDate", endDate);
                parameters.Add("@ProjectId", projectId);
                return ExecuteDataSet("proc_RptHireBillReport", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetHireBillPrivateReport(DateTime startDate, DateTime endDate, int vehicleId, 
            out DataSet pumpStationDataSet, out DataSet lubricantsDataSet)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@StartDate", startDate);
                parameters.Add("@EndDate", endDate);
                parameters.Add("@VehicleId", vehicleId);

                var detailsDataSet = ExecuteDataSet("dbo.proc_RptHireBillPrivateReport", parameters);
                pumpStationDataSet = ExecuteDataSet("dbo.proc_RptHireBillPrivateReportPumpstations", parameters);
                lubricantsDataSet = ExecuteDataSet("dbo.proc_RptHireBillPrivateReportLubricants", parameters);
                return detailsDataSet;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetDriverNames()
        {
            return ExecuteDataSet("dbo.proc_GetDriverNames", null);
        }

        public DataSet GetWorkDoneReport(DateTime startDate, DateTime endDate, int vehicleId)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@StartDate", startDate);
                parameters.Add("@EndDate", endDate);
                parameters.Add("@VehicleId", vehicleId);

                return ExecuteDataSet("dbo.proc_RptWorkDoneReport", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
