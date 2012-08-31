using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CECRunningChart.Core;
using System.Data;

namespace CECRunningChart.Data.Runningchart
{
    public class RunningchartDataProvider : BaseDataProvider, IRunningchartDataProvider
    {
        public int GetNextRunningchartId()
        {
            try
            {
                int current = ExecuteScalar("proc_GetNextRunningchartId", null);
                return current + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AddRunningchart(Core.Runningchart runningChart)
        {
            int runningchartId = 0;
            try
            {
                // 1. Add details to dbo.Runningchart table
                Parameters chartParameters = new Parameters();
                AddRunningChartParameters(runningChart, chartParameters);
                var output = ExecuteNoneQueryWithOutputParams("proc_AddRunningChart", chartParameters);
                runningchartId = Convert.ToInt32(output["@RunningchartId"]);

                // 2. Add details to dbo.RunningchartDetails table
                Parameters chartDetailsParameters;
                foreach (var detail in runningChart.RunningchartDetails)
                {
                    detail.RunningchartId = runningchartId;
                    chartDetailsParameters = new Parameters();
                    AddRunningchartDetailsParameters(detail, chartDetailsParameters);
                    ExecuteNoneQuery("proc_AddRunningchartDetails", chartDetailsParameters);
                }

                // 3. Add details to dbo.RunningchartPumpstation table
                Parameters chartPumpstationParameters;
                foreach (var pumpstation in runningChart.RunningchartPumpstation)
                {
                    pumpstation.RunningchartId = runningchartId;
                    chartPumpstationParameters = new Parameters();
                    AddRunningchartPumpstationParams(pumpstation, chartPumpstationParameters);
                    ExecuteNoneQuery("proc_AddRunningchartPumpstation", chartPumpstationParameters);
                }

                // 4. Add details to dbo.RunningchartLubricants table
                Parameters chartLubricantParameters;
                foreach (var lubricant in runningChart.RunningchartLubricants)
                {
                    lubricant.RunningchartId = runningchartId;
                    chartLubricantParameters = new Parameters();
                    AddRunningchartLubricantParams(lubricant, chartLubricantParameters);
                    ExecuteNoneQuery("proc_AddRunningchartLubricant", chartLubricantParameters);
                }

                return runningchartId;
            }
            catch (Exception)
            {
                if (runningchartId > 0)
                {
                    Parameters cleanupParameters = new Parameters();
                    cleanupParameters.Add("@RunningchartId", runningchartId);
                    ExecuteNoneQuery("proc_CleanupRunningchartRecords", cleanupParameters);
                }
                throw;
            }
        }

        //public DataSet GetLatestRunningCharts(int runningchartId)
        //{
        //    //Parameters chartParameters = new Parameters();
        //    //chartParameters.Add("@RunningchartId", runningchartId);
        //    //return ExecuteDataSet("proc_GetRunningchartById", chartParameters);
        //    return ExecuteDataSet("proc_GetLatestRunningcharts", null);
        //}

        #region Private Methods

        private void AddRunningChartParameters(Core.Runningchart runningChart, Parameters parameters)
        {
            parameters.Add("@BillNumber", runningChart.BillNumber);
            parameters.Add("@BillDate", runningChart.BillDate);
            parameters.Add("@DriverName", runningChart.DriverName);
            parameters.Add("@VehicleId", runningChart.VehicleId);
            //parameters.Add("@VehicleRate", runningChart.VehicleRate); Will be added inside sp
            parameters.Add("@FuelLeftBegning", runningChart.FuelLeftBegning);
            parameters.Add("@FuelLeftEnd", runningChart.FuelLeftEnd);
            parameters.Add("@FuelUsageOfDay", runningChart.FuelUsageOfDay);
            if (string.IsNullOrWhiteSpace(runningChart.DailyNote))
                parameters.Add("@DailyNote", DBNull.Value);
            else
                parameters.Add("@DailyNote", runningChart.DailyNote);
            parameters.Add("@DayStartime", runningChart.DayStartime);
            parameters.Add("@DayEndTime", runningChart.DayEndTime);
            parameters.Add("@EnteredBy", runningChart.EnteredBy);
            parameters.Add("@RunningchartId", 0, System.Data.ParameterDirection.Output);
        }

        private void AddRunningchartDetailsParameters(RunningchartDetails runningchartDetails, Parameters parameters)
        {
            parameters.Add("@RunningchartId", runningchartDetails.RunningchartId);
            parameters.Add("@StartTime", runningchartDetails.StartTime);
            parameters.Add("@EndTime", runningchartDetails.EndTime);
            parameters.Add("@TimeDifference", runningchartDetails.TimeDifference);
            parameters.Add("@StartMeter", runningchartDetails.StartMeter);
            parameters.Add("@EndMeter", runningchartDetails.EndMeter);
            parameters.Add("@MeterDifference", runningchartDetails.MeterDifference);
            parameters.Add("@ProjectId", runningchartDetails.ProjectId);
            parameters.Add("@ProjectManagerName", runningchartDetails.ProjectManagerName);
            parameters.Add("@RentalTypeId", runningchartDetails.RentalTypeId);
        }

        private void AddRunningchartPumpstationParams(RunningchartPumpstation pumpstation, Parameters parameters)
        {
            parameters.Add("@RunningchartId", pumpstation.RunningchartId);
            parameters.Add("@PumpstationId", pumpstation.PumpstationId);
            parameters.Add("@Amount", pumpstation.Amount);
        }

        private void AddRunningchartLubricantParams(RunningchartLubricant lubricant, Parameters parameters)
        {
            parameters.Add("@RunningchartId", lubricant.RunningchartId);
            parameters.Add("@PumpstationId", lubricant.PumpstationId);
            parameters.Add("@LubricantTypeId", lubricant.LubricantTypeId);
            parameters.Add("@Amount", lubricant.Amount);
        }

        #endregion


        public DataSet GetLatestRunningCharts()
        {
            try
            {
                //return ExecuteDataSet("proc_GetLatestRunningcharts", null);
                return ExecuteDataSet("proc_GetNoneApprovedRunningcharts", null);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
