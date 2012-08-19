using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CECRunningChart.Web.Models.Runningchart;
using CECRunningChart.Services.Pumpstation;
using CECRunningChart.Web.Helpers;
using CECRunningChart.Services.Vehicle;
using CECRunningChart.Services.ProjectService;
using CECRunningChart.Web.Models.Pumpstation;
using CECRunningChart.Core;
using CECRunningChart.Services.Runningchart;
using CECRunningChart.Web.Common;

namespace CECRunningChart.Web.Controllers
{
    [Authorize]
    public class RunningchartController : Controller
    {
        IRunningchartService runningchartService;

        public RunningchartController()
        {
            runningchartService = new RunningchartService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var laterstCharts = runningchartService.GetLatestRunningCharts();
            var model = ModelMapper.GetRunningchartModel(laterstCharts);

            return View(model);
        }

        //
        // GET: /Runningchart/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            IVehicleService vehicleServcie = new VehicleService();

            RunningchartModel model = new RunningchartModel();
            model.BillDate = DateTime.Now;
            model.RunningchartId = runningchartService.GetNextRunningchartId();
            model.Vehicles = ModelMapper.GetVehicleModelList(vehicleServcie.GetAllVehicles());
            
            return View(model);
        } 

        [HttpPost]
        public ActionResult Create(RunningchartModel model)
        {
            try
            {
                IVehicleService vehicleServcie = new VehicleService();
                Runningchart runningChart = ModelMapper.GetRunningchartFromRunningchartModel(model);
                runningChart.VehicleRate = 10; //todo: vehicleServcie.GetVehicle(model.SelectedVehicleId).FuelUsage;
                int chartId = runningchartService.AddRunningchart(runningChart);
                ViewBag.LastChartId = chartId;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult PoulatePumpstationItems(bool isAddingNewItem)
        {
            RunningchartModel model = new RunningchartModel();
            List<ChartPumpstationItemModel> existingPumpstationItems = new List<ChartPumpstationItemModel>();
            UpdateModel<List<ChartPumpstationItemModel>>(existingPumpstationItems);

            IPumpstationService pumpstationService = new PumpstationService();
            model.Pumpstations = ModelMapper.GetPumpStationModelList(pumpstationService.GetAllPumpstations());
            model.SelectedPumpstations = new List<ChartPumpstationItemModel>();

            // Add existing chart items
            foreach (var item in existingPumpstationItems)
            {
                if (!item.IsRemoving)
                {
                    model.SelectedPumpstations.Add(item);
                }
            }

            // Add new chart item
            if (isAddingNewItem)
            {
                model.SelectedPumpstations.Add(new ChartPumpstationItemModel()
                {
                    SelectedPumpstationId = 0,
                    PumpAmount = 0
                });
            }

            return PartialView("_Pumpstations", model);
        }

        [HttpPost]
        public ActionResult PoulateChartItems(bool isAddingNewItem, bool isVehicle)
        {
            RunningchartModel model = new RunningchartModel();
            List<ChartItemModel> existingChartItems = new List<ChartItemModel>();
            UpdateModel<List<ChartItemModel>>(existingChartItems);

            IProjectService projectService = new ProjectService();
            model.Projects = ModelMapper.GetProjectModelList(projectService.GetAllActiveProjects());
            model.SelectedChartItems = new List<ChartItemModel>();
            model.isVehicle = isVehicle;

            // Add existing chart items
            foreach (var item in existingChartItems)
            {
                if (!item.IsRemoving)
                {
                    model.SelectedChartItems.Add(item);
                }
            }

            // Add new chart item
            if (isAddingNewItem)
            {
                ChartItemModel newChartItem = new ChartItemModel()
                {
                    StartTime = string.Empty,
                    EndTime = string.Empty,
                    SelectedProjectId = 0,
                    SelectedProjectManager = string.Empty
                };

                if (existingChartItems.Count > 0)
                {
                    newChartItem.SelectedProjectId = existingChartItems[0].SelectedProjectId;
                    newChartItem.SelectedProjectManager = existingChartItems[0].SelectedProjectManager;
                }

                model.SelectedChartItems.Add(newChartItem);
            }

            return PartialView("_ChartItems", model);
        }
        
        //
        // GET: /Runningchart/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Runningchart/Edit/5

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
        // GET: /Runningchart/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Runningchart/Delete/5

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
