using System;
using System.Web.Mvc;
using CECRunningChart.Services.Pumpstation;
using CECRunningChart.Services.ReportService;
using CECRunningChart.Web.Common;
using CECRunningChart.Web.Helpers;

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
        public ActionResult DriverTimeSheet()
        {
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
    }
}
