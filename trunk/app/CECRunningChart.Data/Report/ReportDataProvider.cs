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

        #endregion
    }
}
