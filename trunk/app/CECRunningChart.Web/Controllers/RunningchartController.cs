using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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
using CECRunningChart.Web.Reports.DataSets;
using CrystalDecisions.CrystalReports.Engine;

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

        #region Public Methods

        [HttpGet]
        public ActionResult Index(int? lastChartId)
        {
            IVehicleService vehicleServcie = new VehicleService();
            List<Runningchart> runningCharts = new List<Runningchart>();
            var user = Session[SessionKeys.UserInfo] as UserModel;

            if (user.Role == UserRole.Admin)
            {
                runningCharts = runningchartService.GetNoneApprovedRunningCharts();
            }
            else if (user.Role == UserRole.RunningChartInspector)
            {
                //TODO : Limit running charts by a criteria like inspector projects
                runningCharts = runningchartService.GetNoneApprovedRunningCharts();
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
        public ActionResult Create()
        {
            IVehicleService vehicleServcie = new VehicleService();
            IProjectService projectService = new ProjectService();

            RunningchartModel model = new RunningchartModel();
            model.BillDate = DateTime.Now;
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
        
        [HttpGet]
        public ActionResult Approve(int id)
        {
            var model = GetRunningchartModel(id);
            return View("Details", model);
        }

        [HttpPost]
        public ActionResult Approve(RunningchartModel model)
        {
            try
            {
                var user = Session[SessionKeys.UserInfo] as UserModel;
                runningchartService.ApproveRunningChart(model.RunningchartId, user.Id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public JsonResult FuelLeftBegningOfDay(int vehicleId)
        {
            decimal fuelLeft = runningchartService.GetFuelLeftBegningOfDay(vehicleId);
            return Json(new { FuelLeftBegningOfDay = fuelLeft }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult History()
        {
            IVehicleService vehicleServcie = new VehicleService();
            List<Runningchart> runningCharts = new List<Runningchart>();
            var user = Session[SessionKeys.UserInfo] as UserModel;

            if (user.Role == UserRole.Admin)
            {
                runningCharts = runningchartService.GetApprovedRunningCharts();
            }
            else if (user.Role == UserRole.RunningChartInspector)
            {
                //TODO : Limit running charts by a criteria like inspector projects
                runningCharts = runningchartService.GetApprovedRunningCharts();
            }
            else if (user.Role == UserRole.RunningChartOperator)
            {
                runningCharts = runningchartService.GetOperatorApprovedRunningcharts(user.Id);
            }

            var model = ModelMapper.GetRunningchartModelList(runningCharts);
            ViewBag.Vehicles = ModelMapper.GetVehicleModelList(vehicleServcie.GetAllVehicles());
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = GetRunningchartModel(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Print(int id)
        {
            IVehicleService vehicleServcie = new VehicleService();
            IProjectService projectService = new ProjectService();
            IPumpstationService pumpstationService = new PumpstationService();
            var pumpstations = pumpstationService.GetAllPumpstations();
            var projects = projectService.GetAllActiveProjects();
            var lubricants = vehicleServcie.GetAllLubricantTypes();
            var vehicles = vehicleServcie.GetAllVehicles();
            var chart = runningchartService.GetRunningChart(id);

            dsRunningchart ds = new dsRunningchart();
            DataTable runningchartTable = ds.Tables["Runningchart"].Clone();
            DataTable runningchartDetailsTable = ds.Tables["RunningchartDetails"].Clone();
            DataTable runningchartPumpstationsTable = ds.Tables["RunningchartPumpstation"].Clone();
            DataTable runningchartLubricantsTable = ds.Tables["RunningchartLubricant"].Clone();

            PopulateRunningchartTable(chart, runningchartTable, vehicles);
            PopulateRunningchartDetailsTable(chart.RunningchartDetails, runningchartDetailsTable, projects);
            PopulateRunningchartPumpstationTable(chart.RunningchartPumpstation, runningchartPumpstationsTable, pumpstations);
            PopulateRunningchartLubricantTable(chart.RunningchartLubricants, runningchartLubricantsTable, pumpstations, lubricants);

            ReportClass reportClass = new ReportClass();
            reportClass.FileName = Server.MapPath("~/Reports/Runningchart.rpt");
            reportClass.Load();
            reportClass.SummaryInfo.ReportTitle = "Running Chart";
            reportClass.Database.Tables["Runningchart"].SetDataSource(runningchartTable);
            reportClass.Database.Tables["RunningchartDetails"].SetDataSource(runningchartDetailsTable);
            reportClass.Database.Tables["RunningchartPumpstation"].SetDataSource(runningchartPumpstationsTable);
            reportClass.Database.Tables["RunningchartLubricant"].SetDataSource(runningchartLubricantsTable);

            Stream compStream = reportClass.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(compStream, "application/pdf");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = GetRunningchartModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, string s)
        {
            runningchartService.DeleteRunningChart(id);
            return RedirectToAction("Index");
        }

        #endregion

        #region Private Methods

        private RunningchartModel GetRunningchartModel(int runningChartId)
        {
            IVehicleService vehicleServcie = new VehicleService();
            IProjectService projectService = new ProjectService();
            IPumpstationService pumpstationService = new PumpstationService();
            var chart = runningchartService.GetRunningChart(runningChartId);
            var model = ModelMapper.GetRunningchartModel(chart);
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

            return model;
        }

        private void PopulateRunningchartTable(Runningchart chart, DataTable runningchartTable, List<Vehicle> vehicles)
        {
            DataRow row = runningchartTable.NewRow();
            row["RunningchartId"] = chart.Id;
            row["BillNumber"] = chart.BillNumber;
            row["BillDate"] = chart.BillDate.ToString("d");
            row["DriverName"] = chart.DriverName;
            row["VehicleName"] = vehicles.Single(x => x.Id == chart.VehicleId).VehicleNumber;
            row["VehicleRate"] = chart.VehicleRate.ConvertToDecimalString();
            row["VehicleHireRate"] = chart.VehicleHireRate.ConvertToDecimalString();
            row["FuelRate"] = chart.FuelRate.ConvertToDecimalString();
            row["FuelLeftBegning"] = chart.FuelLeftBegning.ConvertToDecimalString();
            row["FuelLeftEnd"] = chart.FuelLeftEnd.ConvertToDecimalString();
            row["FuelUsageOfDay"] = chart.FuelUsageOfDay.ConvertToDecimalString();
            row["DailyNote"] = chart.DailyNote;
            row["DayStartime"] = chart.DayStartime.ToString("d");
            row["DayEndTime"] = chart.DayEndTime.ToString("d");
            row["EnteredBy"] = chart.EnteredBy;
            row["IsApproved"] = chart.IsApproved;
            row["ApprovedBy"] = chart.ApprovedBy;
            row["ApprovedDate"] = chart.ApprovedDate.ToString("d");
            runningchartTable.Rows.Add(row);
        }

        private void PopulateRunningchartDetailsTable(List<RunningchartDetails> runningchartDetails, 
            DataTable runningchartDetailsTable, List<Project> projects)
        {
            foreach (var item in runningchartDetails)
            {
                DataRow drow = runningchartDetailsTable.NewRow();
                drow["RunningchartDetailsId"] = item.Id;
                drow["RunningchartId"] = item.RunningchartId;
                drow["StartTime"] = item.StartTime.ToString("t");
                drow["EndTime"] = item.EndTime.ToString("t");
                drow["TimeDifference"] = item.TimeDifference;
                drow["StartMeter"] = item.StartMeter;
                drow["EndMeter"] = item.EndMeter;
                drow["MeterDifference"] = item.MeterDifference;
                drow["ProjectName"] = projects.Single(x => x.Id == item.ProjectId).ProjectName;
                drow["ProjectManagerName"] = item.ProjectManagerName;
                drow["RentalTypeId"] = StringEnum.GetEnumStringValue((RentalType)item.RentalTypeId);
                drow["IdleHours"] = item.IdleHours;
                runningchartDetailsTable.Rows.Add(drow);
            }
        }

        private void PopulateRunningchartPumpstationTable(List<RunningchartPumpstation> runningchartPumpstations,
            DataTable runningchartDetailsPumpstationTable, List<PumpStation> pumpstations)
        {
            foreach (var item in runningchartPumpstations)
            {
                DataRow drow = runningchartDetailsPumpstationTable.NewRow();
                drow["RunningchartPumpstationId"] = item.Id;
                drow["RunningchartId"] = item.RunningchartId;
                drow["PumpstationName"] = pumpstations.Single(x => x.Id == item.PumpstationId).PumpStationName;
                drow["PumpAmount"] = item.Amount.ConvertToDecimalString();
                runningchartDetailsPumpstationTable.Rows.Add(drow);
            }
        }

        private void PopulateRunningchartLubricantTable(List<RunningchartLubricant> runningchartLubricants,
            DataTable runningchartLubricantTable, List<PumpStation> pumpstations, List<LubricantType> lubricants)
        {
            foreach (var item in runningchartLubricants)
            {
                DataRow drow = runningchartLubricantTable.NewRow();
                drow["RunningchartLubricantId"] = item.Id;
                drow["RunningchartId"] = item.RunningchartId;
                drow["PumpstationName"] = pumpstations.Single(x => x.Id == item.PumpstationId).PumpStationName;
                drow["LubricantType"] = lubricants.Single(x => x.Id == item.LubricantTypeId).LubricantName;
                drow["PumpAmount"] = item.Amount.ConvertToDecimalString();
                runningchartLubricantTable.Rows.Add(drow);
            }
        }

        #endregion
    }
}
