using System;
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
        public ActionResult DriverTimeSheet(string driverName)
        {
            var report = reportService.GetDriverTimeSheetReport(driverName);
            var model = ModelMapper.GetDriverOperatorTimeSheetModelList(report);
            ViewBag.DriverOperatorName = driverName;
            return View(model);
        }

        [HttpGet]
        public ActionResult TimeSheetPrint(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(name);
            
            DataTable dataTable = GetDriverOperatorTimeSheetTable(name);
            ReportClass reportClass = new ReportClass();
            reportClass.FileName = Server.MapPath("~/Reports/Timesheet.rpt");
            reportClass.Load();
            reportClass.SummaryInfo.ReportTitle = "Driver / Operator Time Sheet";
            reportClass.Database.Tables["DriverOperatorTimeSheet"].SetDataSource(dataTable);
            reportClass.SetParameterValue("DriverOperatorNameParameter", name);

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

            ViewBag.IsVehicle = vehicle.IsVehicle;
            ViewBag.OwnerName = vehicle.OwnerName;
            ViewBag.HireRate = vehicle.HireRate.ToString("N");
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.VehicleNumber = vehicle.VehicleNumber;

            return View(modelhp);
        }

        #endregion

        #endregion

        #region Private Methods

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
                row["KmHrDone"] = item.KmHrDone;
                row["TotalFuelUsage"] = item.TotalFuelUsage;
                row["VehicleRate"] = item.VehicleRate.ToString() + " Km/L";
                row["ActualRate"] = item.ActualRate.ToString("N") + " Km/L";
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
                row["KmHrDone"] = item.KmHrDone;
                row["FuelDrawn"] = item.FuelDrawn;
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
                    row["FuelQty"] = item.FuelQty;
                    row["FuelRate"] = item.FuelRate;
                    row["FuelAmount"] = (item.FuelQty * item.FuelRate).ToString();
                }
                if (item.LubricantQty > 0)
                {
                    row["LubricantType"] = item.LubricantType;
                    row["LubricantQty"] = item.LubricantQty;
                    row["LubricantRate"] = item.LubricantRate;
                    row["LubricantAmount"] = (item.LubricantQty * item.LubricantRate).ToString();
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
                    row["WorkDoneKm"] = item.KmHrDone;
                    row["RateHr"] = item.VehicleHireRate;
                }
                else
                {
                    row["WorkDoneHr"] = item.KmHrDone;
                    row["RateKm"] = item.VehicleHireRate;
                }
                row["Amount"] = item.Amount;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private DataTable GetDriverOperatorTimeSheetTable(string driverName)
        {
            var report = reportService.GetDriverTimeSheetReport(driverName);
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
                row["InTime"] = item.InTime;
                row["OutTime"] = item.OutTime;
                row["OTHours"] = item.OTHours;
                if (item.IsVehicle)
                    row["Km"] = item.WorkDone;
                else
                    row["Hr"] = item.WorkDone;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        #endregion
    }
}
