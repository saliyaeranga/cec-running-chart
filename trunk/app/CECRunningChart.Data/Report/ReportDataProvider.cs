﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                return ExecuteDataSet("proc_FuelConsumptionReport", parameters);
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

        public DataSet GetDriverTimeSheetReport(string driverName)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@DriverOperatorName", driverName);
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

        #endregion
    }
}
