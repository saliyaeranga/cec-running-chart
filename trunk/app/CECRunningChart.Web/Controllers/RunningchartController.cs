using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CECRunningChart.Common;
using CECRunningChart.Core;
using CECRunningChart.Services.ProjectService;
using CECRunningChart.Services.Pumpstation;
using CECRunningChart.Services.Runningchart;
using CECRunningChart.Services.Vehicle;
using CECRunningChart.Web.Helpers;
using CECRunningChart.Web.Models.Runningchart;
using CECRunningChart.Web.Models.User;

namespace CECRunningChart.Web.Controllers
{
    [Authorize]
    public class RunningchartController : Controller
    {
        #region Private Members

        private readonly IRunningchartService runningchartService;

        #endregion

        #region Constructor

        public RunningchartController()
        {
            runningchartService = new RunningchartService();
        }

        #endregion

        [HttpGet]
        public ActionResult Index(int? lastChartId)
        {
            IVehicleService vehicleServcie = new VehicleService();
            List<Runningchart> runningCharts = new List<Runningchart>();
            var user = Session[SessionKeys.UserInfo] as UserModel;

            if (user.Role == UserRole.Admin)
            {
                runningCharts = runningchartService.GetNonePaarovedRunningCharts();
            }
            else if (user.Role == UserRole.RunningChartInspector)
            {
                //TODO
            }
            else if (user.Role == UserRole.RunningChartOperator)
            {
                runningCharts = runningchartService.GetOperatorNoneApprovedRunningcharts(user.Id);
            }

            if (lastChartId.HasValue)
            {
                ViewBag.LastChartId = lastChartId.Value;
            }

            var model = ModelMapper.GetRunningchartModelList(runningCharts);
            ViewBag.Vehicles = ModelMapper.GetVehicleModelList(vehicleServcie.GetAllVehicles());
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            IVehicleService vehicleServcie = new VehicleService();
            IProjectService projectService = new ProjectService();

            RunningchartModel model = new RunningchartModel();
            model.BillDate = DateTime.Now;
            model.RunningchartId = runningchartService.GetNextRunningchartId();
            model.Vehicles = ModelMapper.GetVehicleModelList(vehicleServcie.GetAllVehicles());
            model.Lubricants = ModelMapper.GetLubricantModelList(vehicleServcie.GetAllLubricantTypes());
            model.Projects = ModelMapper.GetProjectModelList(projectService.GetAllActiveProjects());

            ViewBag.Mode = "create";
            return View(model);
        } 

        [HttpPost]
        public ActionResult Create(RunningchartModel model)
        {
            try
            {
                Runningchart runningChart = ModelMapper.GetRunningchartFromRunningchartModel(model);
                runningChart.EnteredBy = (Session[SessionKeys.UserInfo] as UserModel).Id; // Set DEO
                int chartId = runningchartService.AddRunningchart(runningChart);
                //ViewBag.LastChartId = chartId;

                return RedirectToAction("index", new { lastChartId = chartId });
            }
            catch
            {
                IVehicleService vehicleServcie = new VehicleService();
                IProjectService projectService = new ProjectService();

                model.RunningchartId = runningchartService.GetNextRunningchartId();
                model.Vehicles = ModelMapper.GetVehicleModelList(vehicleServcie.GetAllVehicles());
                model.Lubricants = ModelMapper.GetLubricantModelList(vehicleServcie.GetAllLubricantTypes());
                model.Projects = ModelMapper.GetProjectModelList(projectService.GetAllActiveProjects());

                return View(model);
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
        public ActionResult PoulateLubricantItems(bool isAddingNewItem)
        {
            IVehicleService vehicleServcie = new VehicleService();
            RunningchartModel model = new RunningchartModel();
            List<ChartLubricantItemModel> existingLubricantItems = new List<ChartLubricantItemModel>();
            UpdateModel<List<ChartLubricantItemModel>>(existingLubricantItems);

            IPumpstationService pumpstationService = new PumpstationService();
            model.Pumpstations = ModelMapper.GetPumpStationModelList(pumpstationService.GetAllPumpstations());
            model.Lubricants = ModelMapper.GetLubricantModelList(vehicleServcie.GetAllLubricantTypes());
            model.SelectedLubricants = new List<ChartLubricantItemModel>();

            // Add existing chart items
            foreach (var item in existingLubricantItems)
            {
                if (!item.IsRemoving)
                {
                    model.SelectedLubricants.Add(item);
                }
            }

            // Add new chart item
            if (isAddingNewItem)
            {
                model.SelectedLubricants.Add(new ChartLubricantItemModel()
                {
                    SelectedPumpstationId = 0,
                    SelectedLubricantTypeId = 0,
                    PumpAmount = 0
                });
            }

            return PartialView("_Lubricants", model);
        }

        [HttpPost]
        public ActionResult PoulateChartItems(bool isAddingNewItem, bool isVehicle)
        {
            RunningchartModel model = new RunningchartModel();
            List<ChartItemModel> existingChartItems = new List<ChartItemModel>();
            UpdateModel<List<ChartItemModel>>(existingChartItems);

            IProjectService projectService = new ProjectService();
            model.Projects = ModelMapper.GetProjectModelList(projectService.GetAllActiveProjects());
            model.VehicleRentalTypes = new List<VehicleRentalTypeModel>()
            {
                new VehicleRentalTypeModel() { Id = (int)RentalType.Company, RentalTypeName = StringEnum.GetEnumStringValue(RentalType.Company) },
                new VehicleRentalTypeModel() { Id = (int)RentalType.CompanyHired, RentalTypeName = StringEnum.GetEnumStringValue(RentalType.CompanyHired) },
                new VehicleRentalTypeModel() { Id = (int)RentalType.Hired, RentalTypeName = StringEnum.GetEnumStringValue(RentalType.Hired) }
            }; // Not worth to do a DB call since this is very static

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
                    newChartItem.SelectedRentalTypeId = existingChartItems[0].SelectedRentalTypeId;
                }

                model.SelectedChartItems.Add(newChartItem);
            }

            return PartialView("_ChartItems", model);
        }
        
        //
        // GET: /Runningchart/Edit/5
 
        public ActionResult Edit(int id)
        {
            IVehicleService vehicleServcie = new VehicleService();
            IProjectService projectService = new ProjectService();
            IPumpstationService pumpstationService = new PumpstationService();

            var chart = runningchartService.GetRunningChart(id);
            var model = ModelMapper.GetRunningchartModel(chart);
            model.RunningchartId = runningchartService.GetNextRunningchartId();
            model.Vehicles = ModelMapper.GetVehicleModelList(vehicleServcie.GetAllVehicles());
            model.Lubricants = ModelMapper.GetLubricantModelList(vehicleServcie.GetAllLubricantTypes());
            model.Projects = ModelMapper.GetProjectModelList(projectService.GetAllActiveProjects());
            model.Pumpstations = ModelMapper.GetPumpStationModelList(pumpstationService.GetAllPumpstations());
            model.VehicleRentalTypes = new List<VehicleRentalTypeModel>()
            {
                new VehicleRentalTypeModel() { Id = (int)RentalType.Company, RentalTypeName = StringEnum.GetEnumStringValue(RentalType.Company) },
                new VehicleRentalTypeModel() { Id = (int)RentalType.CompanyHired, RentalTypeName = StringEnum.GetEnumStringValue(RentalType.CompanyHired) },
                new VehicleRentalTypeModel() { Id = (int)RentalType.Hired, RentalTypeName = StringEnum.GetEnumStringValue(RentalType.Hired) }
            }; // Not worth to do a DB call since this is very static

            //ViewBag.Mode = "edit";
            return View("Create", model);
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

        ////
        //// GET: /Runningchart/Delete/5
 
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Runningchart/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
 
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
