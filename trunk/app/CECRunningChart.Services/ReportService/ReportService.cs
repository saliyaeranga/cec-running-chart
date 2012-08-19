﻿using System;
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
    }
}