using System;
using System.Linq;
using System.Data;
using System.IO;
using System.Web.Mvc;
using CECRunningChart.Services.ProjectService;
using CECRunningChart.Services.Pumpstation;
using CECRunningChart.Services.ReportService;
using CECRunningChart.Services.Vehicle;
using CECRunningChart.Web.Common;
using CECRunningChart.Web.Helpers;
using CECRunningChart.Web.Reports.DataSets;
using CrystalDecisions.CrystalReports.Engine;
using CECRunningChart.Services.Runningchart;
using CECRunningChart.Common;

namespace CECRunningChart.Web.Controllers
{
    [Authorize]
    [CECAuthorize(Roles = "Admin")]
    public class ReportController : Controller
    {
        #region Private Members

        private readonly IReportService reportService;

        #endregion

        #region Constructor

        public ReportController()
        {
            reportService = new ReportService();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #region Fuel Consumption Report

        [HttpGet]
        public ActionResult FuelConsumption()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FuelConsumption(DateTime startDate, DateTime endDate)
        {
            var report = reportService.GetFuelConsumptionReport(startDate, endDate);
            var model = ModelMapper.GetFuelConsumptionReportList(report);
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            return View(model);
        }

        [HttpGet]
        public ActionResult FuelConsumptionPrint(DateTime startDate, DateTime endDate)
        {
            if (startDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("startDate");
            if (endDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("endDate");

            DataTable dataTable = GetFuelConsumptionTable(startDate, endDate);
            ReportClass reportClass = new ReportClass();
            reportClass.FileName = Server.MapPath("~/Reports/FuelConsumptionReport.rpt");
            reportClass.Load();
            reportClass.SummaryInfo.ReportTitle = "Fuel Consumption Report";
            reportClass.Database.Tables["FuelConsumptionReport"].SetDataSource(dataTable);
            reportClass.SetParameterValue("StartDateParameter", startDate.ToString("d"));
            reportClass.SetParameterValue("EndDateParameter", endDate.ToString("d"));

            Stream compStream = reportClass.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(compStream, "application/pdf");
        }

        #endregion

        #region Hired Fuel Report

        [HttpGet]
        public ActionResult HiredFuelReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HiredFuelReport(DateTime startDate, DateTime endDate)
        {
            var report = reportService.GetHiredVehicleFuelReport(startDate, endDate);
            var model = ModelMapper.GetHiredVehicleFuelReportList(report);
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            return View(model);
        }

        [HttpGet]
        public ActionResult HiredFuelReportPrint(DateTime startDate, DateTime endDate)
        {
            if (startDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("startDate");
            if (endDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("endDate");

            DataTable dataTable = GetHiredFuelReportTable(startDate, endDate);
            ReportClass reportClass = new ReportClass();
            reportClass.FileName = Server.MapPath("~/Reports/HiredVehicleFuelReport.rpt");
            reportClass.Load();
            reportClass.SummaryInfo.ReportTitle = "Fuel Report – Hired Vehicle / Machine";
            reportClass.Database.Tables["HiredVehicleFuelReport"].SetDataSource(dataTable);
            reportClass.SetParameterValue("StartDateParameter", startDate.ToString("d"));
            reportClass.SetParameterValue("EndDateParameter", endDate.ToString("d"));

            Stream compStream = reportClass.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(compStream, "application/pdf");
        }

        #endregion

        #region Driver Operator Time Sheet Report

        [HttpGet]
        public ActionResult DriverTimeSheet()
        {
            var drivers = reportService.GetDriverNames();
            ViewBag.DriverNames = drivers;
            return View();
        }

        [HttpPost]
        public ActionResult DriverTimeSheet(string driverName, DateTime startDate, DateTime endDate)
        {
            var report = reportService.GetDriverTimeSheetReport(driverName, startDate, endDate);
            var model = ModelMapper.GetDriverOperatorTimeSheetModelList(report);
            ViewBag.DriverOperatorName = driverName;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            return View(model);
        }

        [HttpGet]
        public ActionResult TimeSheetPrint(string name, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(name);
            if (startDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("startDate");
            if (endDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("endDate");

            DataTable dataTable = GetDriverOperatorTimeSheetTable(name, startDate, endDate);
            ReportClass reportClass = new ReportClass();
            reportClass.FileName = Server.MapPath("~/Reports/Timesheet.rpt");
            reportClass.Load();
            reportClass.SummaryInfo.ReportTitle = "Driver / Operator Time Sheet";
            reportClass.Database.Tables["DriverOperatorTimeSheet"].SetDataSource(dataTable);
            reportClass.SetParameterValue("DriverOperatorNameParameter", name);
            reportClass.SetParameterValue("StartDateParameter", startDate.ToString("d"));
            reportClass.SetParameterValue("EndDateParameter", endDate.ToString("d"));

            Stream compStream = reportClass.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(compStream, "application/pdf");
        }

        #endregion

        #region Fuel And Lubricant Report

        [HttpGet]
        public ActionResult FuelAndLubricant()
        {
            IPumpstationService pumpstationService = new PumpstationService();
            ViewBag.PumpStations = ModelMapper.GetPumpStationModelList(pumpstationService.GetAllPumpstations());
            return View();
        }

        [HttpPost]
        public ActionResult FuelAndLubricant(DateTime startDate, DateTime endDate, int pumpstationId, string pumpstationName)
        {
            var report = reportService.GetFuelAndLubricantReport(startDate, endDate, pumpstationId);
            var model = ModelMapper.GetFuelAndLubricantReportModelList(report);
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.PumpstationId = pumpstationId;
            ViewBag.Pumpstation = pumpstationName;
            return View(model);
        }

        [HttpGet]
        public ActionResult FuelAndLubricantPrint(DateTime startDate, DateTime endDate, int pumpstationId, string pumpstationName)
        {
            if (startDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("startDate");
            if (endDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("endDate");
            if (pumpstationId == 0)
                throw new InvalidArgumentException("Pumpstation Id can not be 0", EngineExceptionErrorID.InvalidArgument);

            DataTable dataTable = GetFuelAndLubricantReportTable(startDate, endDate, pumpstationId);
            ReportClass reportClass = new ReportClass();
            reportClass.FileName = Server.MapPath("~/Reports/FuelAndLubricantReport.rpt");
            reportClass.Load();
            reportClass.SummaryInfo.ReportTitle = "Fuel & Lubricant Report";
            reportClass.Database.Tables["FuelAndLubricantReport"].SetDataSource(dataTable);
            reportClass.SetParameterValue("StartDateParameter", startDate.ToString("d"));
            reportClass.SetParameterValue("EndDateParameter", endDate.ToString("d"));
            reportClass.SetParameterValue("PumpstationParameter", pumpstationName);

            Stream compStream = reportClass.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(compStream, "application/pdf");
        }

        #endregion

        #region Vehicle Machine Register Report

        [HttpGet]
        public ActionResult VehicleMachineRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VehicleMachineRegister(DateTime startDate, DateTime endDate)
        {
            var report = reportService.GetVehicleMachineRegisterReport(startDate, endDate);
            var model = ModelMapper.GetVehicleMachineRegisterModelList(report);
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            return View(model);
        }

        [HttpGet]
        public ActionResult VehicleMachineRegisterPrint(DateTime startDate, DateTime endDate)
        {
            if (startDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("startDate");
            if (endDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("endDate");

            DataTable dataTable = GetVehicleMachineRegisterReportTable(startDate, endDate);
            ReportClass reportClass = new ReportClass();
            reportClass.FileName = Server.MapPath("~/Reports/VehicleMachineRegisterReport.rpt");
            reportClass.Load();
            reportClass.SummaryInfo.ReportTitle = "Vehicle Machine Register Report";
            reportClass.Database.Tables["VehicleMachineRegister"].SetDataSource(dataTable);
            reportClass.SetParameterValue("StartDateParameter", startDate.ToString("d"));
            reportClass.SetParameterValue("EndDateParameter", endDate.ToString("d"));

            Stream compStream = reportClass.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(compStream, "application/pdf");
        }

        #endregion

        #region Hire Bill Report

        [HttpGet]
        public ActionResult HireBill()
        {
            IProjectService projectService = new ProjectService();
            ViewBag.Projects = ModelMapper.GetProjectModelList(projectService.GetAllProjects());
            return View();
        }

        [HttpPost]
        public ActionResult HireBill(DateTime startDate, DateTime endDate, int projectId, string projectName)
        {
            var report = reportService.GetHireBillReport(startDate, endDate, projectId);
            var model = ModelMapper.GetHireBillReportModelList(report);
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.ProjectId = projectId;
            ViewBag.ProjectName = projectName;
            return View(model);
        }

        [HttpGet]
        public ActionResult HireBillPrint(DateTime startDate, DateTime endDate, int projectId, string projectName)
        {
            if (startDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("startDate");
            if (endDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("endDate");
            if (projectId == 0)
                throw new InvalidArgumentException("Project Id can not be 0", EngineExceptionErrorID.InvalidArgument);

            DataTable dataTable = GetHireBillReportTable(startDate, endDate, projectId);
            ReportClass reportClass = new ReportClass();
            reportClass.FileName = Server.MapPath("~/Reports/HireBillReport.rpt");
            reportClass.Load();
            reportClass.SummaryInfo.ReportTitle = "Hire Bill Report";
            reportClass.Database.Tables["HireBillReport"].SetDataSource(dataTable);
            reportClass.SetParameterValue("StartDateParameter", startDate.ToString("d"));
            reportClass.SetParameterValue("EndDateParameter", endDate.ToString("d"));
            reportClass.SetParameterValue("ProjectParameter", projectName);

            Stream compStream = reportClass.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(compStream, "application/pdf");
        }

        #endregion

        #region Hire Bill Private Report

        [HttpGet]
        public ActionResult HireBillPrivate()
        {
            IVehicleService vehicleService = new VehicleService();
            ViewBag.Vehicles = ModelMapper.GetVehicleModelList(vehicleService.GetAllHiredVehicles());
            return View();
        }

        [HttpPost]
        public ActionResult HireBillPrivate(DateTime startDate, DateTime endDate, int vehicleNo)
        {
            IVehicleService vehicleService = new VehicleService();
            var vehicle = vehicleService.GetVehicle(vehicleNo);
            var reporthp = reportService.GetHireBillPrivateReport(startDate, endDate, vehicleNo);
            var modelhp = ModelMapper.GetHireBillPrivateReportModelList(reporthp);

            ViewBag.VehicleNo = vehicle.Id;
            ViewBag.IsVehicle = vehicle.IsVehicle;
            ViewBag.OwnerName = vehicle.OwnerName;
            ViewBag.HireRate = vehicle.HireRate.ConvertToDecimalString(); //.ToString("N");
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.VehicleNumber = vehicle.VehicleNumber;

            return View(modelhp);
        }

        [HttpGet]
        public ActionResult HireBillPrivatePrint(DateTime startDate, DateTime endDate, int vehicleNo)
        {
            if (startDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("startDate");
            if (endDate.Equals(DateTime.MinValue))
                throw new ArgumentNullException("endDate");
            if (vehicleNo == 0)
                throw new InvalidArgumentException("Vehicle No can not be 0", EngineExceptionErrorID.InvalidArgument);

            IVehicleService vehicleService = new VehicleService();
            var vehicle = vehicleService.GetVehicle(vehicleNo);
            DataTable dataTable = GetHireBillPrivateReportTable(startDate, endDate, vehicleNo, vehicle.IsVehicle);
            ReportClass reportClass = new ReportClass();
            reportClass.FileName = Server.MapPath("~/Reports/HireBillPrivateReport.rpt");
            reportClass.Load();
            reportClass.SummaryInfo.ReportTitle = "Hire Bill (Private) Report";
            reportClass.Database.Tables["HireBillPrivateReport"].SetDataSource(dataTable);
            reportClass.SetParameterValue("StartDateParameter", startDate.ToString("d"));
            reportClass.SetParameterValue("EndDateParameter", endDate.ToString("d"));
            reportClass.SetParameterValue("VehicleNumberParameter", vehicle.VehicleNumber);
            reportClass.SetParameterValue("OwnerNameParameter", vehicle.OwnerName);
            string measure = vehicle.IsVehicle ? " Rs/Km" : " Rs/Hr";
            reportClass.SetParameterValue("HireRateParameter", vehicle.HireRate.ConvertToDecimalString() + measure);

            Stream compStream = reportClass.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(compStream, "application/pdf");
        }

        #endregion

        [HttpGet]
        public ActionResult testrc()
        {
            IRunningchartService runningchartService = new RunningchartService();
            var chart = runningchartService.GetRunningChart(19);

            return View();
        }

        #endregion

        #region Private Methods

        private DataTable GetHireBillPrivateReportTable(DateTime startDate, DateTime endDate, int vehicleNo, bool isVehicle)
        {
            
            var reporthp = reportService.GetHireBillPrivateReport(startDate, endDate, vehicleNo);
            var modelhp = ModelMapper.GetHireBillPrivateReportModelList(reporthp);
            dsHireBillPrivateReport ds = new dsHireBillPrivateReport();
            DataTable dataTable = ds.Tables[0].Clone();

            var runningChartIds = modelhp.RunningChartIds;
            decimal totalWorkDone = decimal.Zero;
            decimal totalWorkAmount = decimal.Zero;
            decimal totalFuelQty = decimal.Zero;
            decimal totalFuelAmount = decimal.Zero;
            decimal totalLubricantQty = decimal.Zero;
            decimal totalLubricantAmount = decimal.Zero;

            foreach (var chart in runningChartIds)
            {
                var details = modelhp.HireBillPrivateReportDetails.Where(x => x.RunningchartId == chart.Key);
                var fuel = modelhp.HireBillPrivateReportFuel.Where(x => x.RunningchartId == chart.Key);
                var lubricant = modelhp.HireBillPrivateReportLubricants.Where(x => x.RunningchartId == chart.Key);

                var detailsCount = details.Count();
                var fuelCount = fuel.Count();
                var lubriCount = lubricant.Count();
                var maxCountForChart = new int[] { detailsCount, fuelCount, lubriCount }.Max();

                var detailsArray = details.ToArray();
                var fuelArray = fuel.ToArray();
                var lubricantArray = lubricant.ToArray();

                for (int i = 0; i < maxCountForChart; i++)
                {
                    string[] dataValues = new string[15];
                    string chariId = string.Empty;
                    string billDate = string.Empty;
                    // Runningchart
                    if (i == 0)
                    {
                        dataValues[0] = chart.Key.ToString(); // DRC No
                        dataValues[1] = chart.Value.ToString("d"); // Date
                    }
                    // Runningchart details
                    if (i < detailsArray.Length)
                    {
                        dataValues[2] = detailsArray[i].ProjectLocation; // Project Location
                        dataValues[3] = isVehicle ? detailsArray[i].KmHrDone.ConvertToDecimalString() : string.Empty; // Work Done - Km
                        dataValues[4] = isVehicle ? string.Empty : detailsArray[i].KmHrDone.ConvertToDecimalString(); // Work Done - Hour
                        var amt = detailsArray[i].HireAmount;
                        dataValues[5] = amt.ConvertToDecimalString(); // Amount
                        totalWorkDone += detailsArray[i].KmHrDone;
                        totalWorkAmount += amt;
                    }
                    // Runningchart fuel
                    if (i < fuelArray.Length)
                    {
                        dataValues[6] = fuelArray[i].PumpstationName; // Pump Station
                        dataValues[7] = fuelArray[i].Amount.ConvertToDecimalString(); // Qty
                        dataValues[8] = fuelArray[i].FuelRate.ConvertToDecimalString(); // Rate
                        var amt = fuelArray[i].Amount * fuelArray[i].FuelRate;
                        dataValues[9] = amt.ConvertToDecimalString(); // Amount
                        totalFuelQty += fuelArray[i].Amount;
                        totalFuelAmount += amt;
                    }
                    // Runningchart lubricant
                    if (i < lubricantArray.Length)
                    {
                        dataValues[10] = lubricantArray[i].PumpstationName; // Pump Station
                        dataValues[11] = lubricantArray[i].LubricantType; // Lubricant Type
                        dataValues[12] = lubricantArray[i].Amount.ConvertToDecimalString(); // Qty
                        dataValues[13] = lubricantArray[i].LubricantRate.ConvertToDecimalString(); // Rate
                        var amt = lubricantArray[i].Amount * lubricantArray[i].LubricantRate;
                        dataValues[14] = amt.ConvertToDecimalString(); // Amount
                        totalLubricantQty += lubricantArray[i].Amount;
                        totalLubricantAmount += amt;
                    }

                    // Add rows
                    DataRow row = dataTable.NewRow();
                    row["RunningchartId"] = dataValues[0];
                    row["BillDate"] = dataValues[1];

                    row["ProjectLocation"] = dataValues[2];
                    //row["WorkDoneKm"] = dataValues[3];
                    if (string.IsNullOrWhiteSpace(dataValues[3]))
                    {
                        row["WorkDoneKm"] = DBNull.Value;
                    }
                    else
                    {
                        row["WorkDoneKm"] = dataValues[3];
                    }
                    row["WorkDoneHour"] = dataValues[4];
                    //row["WorkDoneAmount"] = dataValues[5];
                    if (string.IsNullOrWhiteSpace(dataValues[5]))
                    {
                        row["WorkDoneAmount"] = DBNull.Value;
                    }
                    else
                    {
                        row["WorkDoneAmount"] = dataValues[5];
                    }

                    row["FuelUsed"] = dataValues[6];
                    //row["FuelUsedQty"] = dataValues[7];
                    if (string.IsNullOrWhiteSpace(dataValues[7]))
                    {
                        row["FuelUsedQty"] = DBNull.Value;
                    }
                    else
                    {
                        row["FuelUsedQty"] = dataValues[7];
                    }
                    row["FuelUsedRate"] = dataValues[8];
                    //row["FuelUsedAmount"] = dataValues[9];
                    if (string.IsNullOrWhiteSpace(dataValues[9]))
                    {
                        row["FuelUsedAmount"] = DBNull.Value;
                    }
                    else
                    {
                        row["FuelUsedAmount"] = dataValues[9];
                    }

                    row["LubricantPumpStation"] = dataValues[10];
                    row["LubricantType"] = dataValues[11];
                    //row["LubricantQty"] = dataValues[12];
                    if (string.IsNullOrWhiteSpace(dataValues[12]))
                    {
                        row["LubricantQty"] = DBNull.Value;
                    }
                    else
                    {
                        row["LubricantQty"] = dataValues[12];
                    }
                    row["LubricantRate"] = dataValues[13];
                    if(string.IsNullOrWhiteSpace(dataValues[14]))
                    {
                        row["LubricantAmount"] = DBNull.Value;
                    }
                    else
                    {
                        row["LubricantAmount"] = dataValues[14];
                    }
                    //row["LubricantAmount"] = dataValues[14];

                    dataTable.Rows.Add(row);
                }
            }
            
            return dataTable;
        }

        private DataTable GetVehicleMachineRegisterReportTable(DateTime startDate, DateTime endDate)
        {
            var report = reportService.GetVehicleMachineRegisterReport(startDate, endDate);
            dsVehicleMachineRegister ds = new dsVehicleMachineRegister();
            DataTable dataTable = ds.Tables[0].Clone();
            int count = 1;

            foreach (var item in report)
            {
                DataRow row = dataTable.NewRow();
                row["No"] = count;
                row["VehicleId"] = item.VehicleId;
                row["VehicleType"] = item.VehicleType;
                row["VehicleNumber"] = item.VehicleNumber;
                row["CompanyCode"] = item.CompanyCode;
                row["VehicleLocation"] = item.VehicleLocation;
                dataTable.Rows.Add(row);
                count++;
            }

            return dataTable;
        }

        private DataTable GetFuelConsumptionTable(DateTime startDate, DateTime endDate)
        {
            var report = reportService.GetFuelConsumptionReport(startDate, endDate);
            dsFuelConsumptionReport ds = new dsFuelConsumptionReport();
            DataTable dataTable = ds.Tables[0].Clone();

            foreach (var item in report)
            {
                DataRow row = dataTable.NewRow();
                row["VehicleId"] = item.VehicleId;
                row["VehicleNumber"] = item.VehicleNumber;
                row["IsVehicle"] = item.IsVehicle;
                row["DriverOperatorName"] = item.DriverOperatorName;
                //row["KmHrDone"] = item.KmHrDone;
                //row["TotalFuelUsage"] = item.TotalFuelUsage;
                row["VehicleRate"] = item.VehicleRate.ConvertToDecimalString() + " Km/L";
                //row["ActualRate"] = item.ActualRate.ConvertToDecimalString() + " Km/L";
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private DataTable GetHiredFuelReportTable(DateTime startDate, DateTime endDate)
        {
            var report = reportService.GetHiredVehicleFuelReport(startDate, endDate);
            dsHiredVehicleFuelReport ds = new dsHiredVehicleFuelReport();
            DataTable dataTable = ds.Tables[0].Clone();

            foreach (var item in report)
            {
                DataRow row = dataTable.NewRow();
                row["VehicleId"] = item.VehicleId;
                row["VehicleNumber"] = item.VehicleNumber;
                row["IsVehicle"] = item.IsVehicle;
                row["DriverOperatorName"] = item.DriverOperatorName;
                row["OwnerName"] = item.OwnerName;
                row["KmHrDone"] = item.KmHrDone.ConvertToDecimalString();
                row["FuelDrawn"] = item.FuelDrawn.ConvertToDecimalString();
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private DataTable GetFuelAndLubricantReportTable(DateTime startDate, DateTime endDate, int pumpstationId)
        {
            var report = reportService.GetFuelAndLubricantReport(startDate, endDate, pumpstationId);
            dsFuelAndLubricantReport ds = new dsFuelAndLubricantReport();
            DataTable dataTable = ds.Tables[0].Clone();

            foreach (var item in report)
            {
                DataRow row = dataTable.NewRow();
                row["RunningchartId"] = item.RunningchartId;
                row["BillDate"] = item.BillDate.ToString("d");
                row["VehicleId"] = item.VehicleId;
                row["VehicleNumber"] = item.VehicleNumber;
                row["IsVehicle"] = item.IsVehicle;
                row["DriverOperatorName"] = item.DriverOperatorName;
                if (item.IsHiredVehicle)
                {
                    row["IsHiredVehicle"] = "YES";
                }
                else
                {
                    row["IsHiredVehicle"] = "NO";
                }
                if (item.FuelQty > 0)
                {
                    row["FuelType"] = item.FuelType;
                    row["FuelQty"] = item.FuelQty.ConvertToDecimalString();
                    row["FuelRate"] = item.FuelRate.ConvertToDecimalString();
                    row["FuelAmount"] = (item.FuelQty * item.FuelRate).ConvertToDecimalString();
                }
                if (item.LubricantQty > 0)
                {
                    row["LubricantType"] = item.LubricantType;
                    row["LubricantQty"] = item.LubricantQty.ConvertToDecimalString();
                    row["LubricantRate"] = item.LubricantRate.ConvertToDecimalString();
                    row["LubricantAmount"] = (item.LubricantQty * item.LubricantRate).ConvertToDecimalString();
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private DataTable GetHireBillReportTable(DateTime startDate, DateTime endDate, int projectId)
        {
            var report = reportService.GetHireBillReport(startDate, endDate, projectId);
            dsHireBillReport ds = new dsHireBillReport();
            DataTable dataTable = ds.Tables[0].Clone();

            foreach (var item in report)
            {
                DataRow row = dataTable.NewRow();
                row["RunningchartId"] = item.RunningchartId;
                row["BillDate"] = item.BillDate.ToString("d");
                row["VehicleNumber"] = item.VehicleNumber;
                row["CompanyCode"] = item.CompanyCode;
                row["IsVehicle"] = item.IsVehicle;
                if (item.IsVehicle)
                {
                    row["WorkDoneKm"] = item.KmHrDone.ConvertToDecimalString();
                    row["RateHr"] = item.VehicleHireRate.ConvertToDecimalString();
                }
                else
                {
                    row["WorkDoneHr"] = item.KmHrDone.ConvertToDecimalString();
                    row["RateKm"] = item.VehicleHireRate.ConvertToDecimalString();
                }
                row["Amount"] = item.Amount.ConvertToDecimalString();
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private DataTable GetDriverOperatorTimeSheetTable(string driverName, DateTime startDate, DateTime endDate)
        {
            var report = reportService.GetDriverTimeSheetReport(driverName, startDate, endDate);
            dsDriverOperatorTimeSheet ds = new dsDriverOperatorTimeSheet();
            DataTable dataTable = ds.Tables[0].Clone();

            foreach (var item in report)
            {
                DataRow row = dataTable.NewRow();
                row["RunningchartId"] = item.RunningchartId;
                row["DriverOperatorName"] = item.DriverOperatorName;
                row["BillDate"] = item.BillDate.ToString("d");
                row["VehicleNumber"] = item.VehicleNumber;
                row["IsVehicle"] = item.IsVehicle;
                row["InTime"] = item.InTime.ToString("t");
                row["OutTime"] = item.OutTime.ToString("t");
                string displayOTHours = item.OTHours <= 0 ? "0" : item.OTHours.ConvertToDecimalString();
                row["OTHours"] = displayOTHours;
                if (item.IsVehicle)
                    row["Km"] = item.WorkDone.ConvertToDecimalString();
                else
                    row["Hr"] = item.WorkDone.ConvertToDecimalString();
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        #endregion
    }
}
