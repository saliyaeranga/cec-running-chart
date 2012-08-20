using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CECRunningChart.Web.Common;
using CECRunningChart.Services.ReportService;
using CECRunningChart.Web.Helpers;

namespace CECRunningChart.Web.Controllers
{
    //[Authorize]
    //[CECAuthorize(Roles = "Admin")]
    public class ReportController : Controller
    {
        private readonly IReportService reportService;

        public ReportController()
        {
            reportService = new ReportService();
        }

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


        //
        // GET: /Report/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Report/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Report/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Report/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Report/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Report/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Report/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
