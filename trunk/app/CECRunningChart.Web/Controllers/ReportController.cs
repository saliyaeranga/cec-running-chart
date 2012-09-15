using System;
using System.Web.Mvc;
using CECRunningChart.Services.ProjectService;
using CECRunningChart.Services.Pumpstation;
using CECRunningChart.Services.ReportService;
using CECRunningChart.Services.Vehicle;
using CECRunningChart.Web.Common;
using CECRunningChart.Web.Helpers;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

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
            ViewBag.Pumpstation = pumpstationName;
            return View(model);
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
            ViewBag.ProjectName = projectName;
            return View(model);
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

        [Authorize]
        public ActionResult Test()
        {
            //DataTable dataTable = new DataTable("testTable");
            ReportClass reportClass = new ReportClass();
            reportClass.FileName = Server.MapPath("~/Reports/TestReport.rpt");
            reportClass.Load();

            //reportClass.Database.Tables["testTable"].SetDataSource(dataTable);

            Stream compStream = reportClass.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(compStream, "application/pdf");
        }
    }
}
