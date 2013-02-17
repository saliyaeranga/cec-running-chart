using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CECRunningChart.Common;
using CECRunningChart.Core;
using CECRunningChart.Web.Models.Project;
using CECRunningChart.Web.Models.Pumpstation;
using CECRunningChart.Web.Models.Reports;
using CECRunningChart.Web.Models.Runningchart;
using CECRunningChart.Web.Models.User;
using CECRunningChart.Web.Models.Vehicle;

namespace CECRunningChart.Web.Helpers
{
    public static class ModelMapper
    {
        #region Pumpstation Mapping

        public static List<PumpstationModel> GetPumpStationModelList(IEnumerable<PumpStation> pumpstations)
        {
            var pumpStationList = from p in pumpstations
                                  select new PumpstationModel
                                  {
                                      Id = p.Id,
                                      PumpStationName = p.PumpStationName,
                                      Description = p.Description
                                  };
            return pumpStationList.ToList<PumpstationModel>();
        }

        #endregion

        #region Project Mappings

        public static ProjectModel GetProjectModel(Project project)
        {
            return new ProjectModel()
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                ProjectLocation = project.ProjectLocation,
                ProjectDescription = project.ProjectDescription,
                ProjectManager = project.ProjectManager,
                IsActiveProject = !project.IsActiveProject
            };
        }

        public static List<ProjectModel> GetProjectModelList(IEnumerable<Project> projects)
        {
            var projectsList = from p in projects
                               select new ProjectModel
                               {
                                   Id = p.Id,
                                   ProjectName = p.ProjectName,
                                   ProjectLocation = p.ProjectLocation,
                                   ProjectDescription = p.ProjectDescription,
                                   ProjectManager = p.ProjectManager,
                                   IsActiveProject = !p.IsActiveProject
                               };
            return projectsList.ToList<ProjectModel>();
        }

        public static Project GetProject(ProjectModel model)
        {
            return new Project()
            {
                Id = model.Id,
                ProjectName = model.ProjectName,
                ProjectLocation = model.ProjectLocation,
                ProjectDescription = model.ProjectDescription,
                ProjectManager = model.ProjectManager,
                IsActiveProject = !model.IsActiveProject
            };
        }

        public static List<VehicleRentalTypeModel> GetVehicleRentalTypeModelList(IEnumerable<VehicleRentalType> types)
        {
            var projectsList = from t in types
                               select new VehicleRentalTypeModel
                               {
                                   Id = t.Id,
                                   RentalTypeName = t.RentalTypeName
                               };
            return projectsList.ToList<VehicleRentalTypeModel>();
        }

        #endregion

        #region Vehicle Mappings

        public static List<VehicleModel> GetVehicleModelList(IEnumerable<Vehicle> vehicles)
        {
            var vehicleList = from v in vehicles
                              select new VehicleModel
                              {
                                  Id = v.Id,
                                  VehicleNumber = v.VehicleNumber,
                                  CompanyCode = v.CompanyCode,
                                  VehicleTypeId = v.VehicleTypeId,
                                  VehicleTypeName = v.VehicleTypeName,
                                  Description = v.Description,
                                  DriverOperatorName = v.DriverOperatorName,
                                  FuelUsage = v.FuelUsage,
                                  FuelTypeId = v.FuelType,
                                  FuelTypeName = v.FuelTypeName,
                                  LubricantTypeId = v.LubricantType,
                                  LubricantTypeName = v.LubricantTypeName,
                                  IsHiredVehicle = v.IsHiredVehicle,
                                  HireRate = v.HireRate,
                                  OwnerName = v.OwnerName,
                                  IsVehicle = v.IsVehicle,
                                  Status = v.Status
                              };
            return vehicleList.ToList<VehicleModel>();
        }

        public static VehicleModel GetVehicleModel(Vehicle vehicle)
        {
            return new VehicleModel()
            {
                Id = vehicle.Id,
                VehicleNumber = vehicle.VehicleNumber,
                CompanyCode = vehicle.CompanyCode,
                VehicleTypeId = vehicle.VehicleTypeId,
                VehicleTypeName = vehicle.VehicleTypeName,
                Description = vehicle.Description,
                DriverOperatorName = vehicle.DriverOperatorName,
                FuelUsage = vehicle.FuelUsage,
                FuelTypeId = vehicle.FuelType,
                FuelTypeName = vehicle.FuelTypeName,
                LubricantTypeId = vehicle.LubricantType,
                LubricantTypeName = vehicle.LubricantTypeName,
                IsHiredVehicle = vehicle.IsHiredVehicle,
                HireRate = vehicle.HireRate,
                OwnerName = vehicle.OwnerName,
                IsVehicle = vehicle.IsVehicle,
                Status = vehicle.Status
            };
        }

        public static Vehicle GetVehicle(VehicleModel model)
        {
            return new Vehicle()
            {
                Id = model.Id,
                VehicleNumber = model.VehicleNumber,
                CompanyCode = model.CompanyCode,
                VehicleTypeId = model.VehicleTypeId,
                VehicleTypeName = model.VehicleTypeName,
                Description = model.Description,
                DriverOperatorName = model.DriverOperatorName,
                FuelUsage = model.FuelUsage,
                FuelType = model.FuelTypeId,
                FuelTypeName = model.FuelTypeName,
                LubricantType = model.LubricantTypeId,
                LubricantTypeName = model.LubricantTypeName,
                IsHiredVehicle = model.IsHiredVehicle,
                HireRate = model.HireRate,
                OwnerName = model.OwnerName,
                IsVehicle = model.IsVehicle,
                Status = model.Status
            };
        }

        public static FuelModel GetFuelModel(FuelType fuelType)
        {
            return new FuelModel()
            {
                Id = fuelType.Id,
                FuelType = fuelType.FuelName,
                FuelRate = fuelType.FuelRate
            };
        }

        public static List<FuelModel> GetFuelModelList(IEnumerable<FuelType> fuelTypes)
        {
            return fuelTypes.Select(x => new FuelModel() { Id = x.Id, FuelType = x.FuelName, FuelRate = x.FuelRate }).ToList<FuelModel>();
        }

        public static FuelType GetFuel(FuelModel model)
        {
            return new FuelType()
            {
                Id = model.Id,
                FuelName = model.FuelType,
                FuelRate = model.FuelRate
            };
        }

        public static LubricantModel GetLubricantModel(LubricantType lubricant)
        {
            return new LubricantModel()
            {
                Id = lubricant.Id,
                LubricantType = lubricant.LubricantName,
                LubricantRate = lubricant.LubricantRate
            };
        }

        public static List<LubricantModel> GetLubricantModelList(IEnumerable<LubricantType> lubricantType)
        {
            return lubricantType.Select(x => new LubricantModel() { Id = x.Id, LubricantType = x.LubricantName, LubricantRate = x.LubricantRate }).ToList<LubricantModel>();
        }

        public static LubricantType GetLubricant(LubricantModel model)
        {
            return new LubricantType()
            {
                Id = model.Id,
                LubricantName = model.LubricantType,
                LubricantRate = model.LubricantRate
            };
        }

        public static List<VehicleTypeModel> GetVehicleTypeModelList(IEnumerable<VehicleType> vehicleTypes)
        {
            return vehicleTypes.Select(x => new VehicleTypeModel() { Id = x.Id, VehicleTypeName = x.VehicleTypeName }).ToList();
        }

        #endregion

        #region Runningchart Mappings

        public static Runningchart GetRunningchartFromRunningchartModel(RunningchartModel model)
        {
            Runningchart runningChart = new Runningchart()
            {
                BillNumber = model.BillNumber,
                BillDate = model.BillDate,
                DriverName = model.DriverName,
                VehicleId = model.SelectedVehicleId,
                //VehicleRate = model.vh
                FuelLeftBegning = model.FuelLeftBegningOfDay,
                FuelLeftEnd = model.FuelLeftEndOfDay,
                FuelUsageOfDay = model.FuelUsageOfDay,
                DailyNote = model.DailyNote,
                IsApproved = model.IsApproved,
                ApprovedBy = model.ApprovedBy,
                EnteredBy = model.EnteredBy,
                RunningchartDetails = new List<RunningchartDetails>(),
                RunningchartPumpstation = new List<RunningchartPumpstation>(),
                RunningchartLubricants = new List<RunningchartLubricant>()
            };

            var startTimePart = Convert.ToDateTime(model.DayStartime);
            var endTimePart = Convert.ToDateTime(model.DayEndTime);
            DateTime startTime = new DateTime(model.BillDate.Year, model.BillDate.Month, model.BillDate.Day,
                startTimePart.Hour, startTimePart.Minute, startTimePart.Second);
            DateTime endTime = new DateTime(model.BillDate.Year, model.BillDate.Month, model.BillDate.Day,
                endTimePart.Hour, endTimePart.Minute, endTimePart.Second);
            runningChart.DayStartime = startTime;
            runningChart.DayEndTime = endTime;

            foreach (var item in model.SelectedChartItems)
            {
                var startProjTimePart = Convert.ToDateTime(item.StartTime);
                var endProjTimePart = Convert.ToDateTime(item.EndTime);
                DateTime startProjTime = new DateTime(model.BillDate.Year, model.BillDate.Month, model.BillDate.Day,
                    startTimePart.Hour, startTimePart.Minute, startTimePart.Second);
                DateTime endProjTime = new DateTime(model.BillDate.Year, model.BillDate.Month, model.BillDate.Day,
                    endTimePart.Hour, endTimePart.Minute, endTimePart.Second);

                runningChart.RunningchartDetails.Add(new RunningchartDetails()
                {
                    StartTime = startProjTime,
                    EndTime = endProjTime,
                    TimeDifference = item.TimeDifference,
                    StartMeter = item.StartMeter,
                    EndMeter = item.EndMeter,
                    MeterDifference = item.MeterDifference,
                    IdleHours = item.IdleHours,
                    ProjectId = item.SelectedProjectId,
                    ProjectManagerName = item.SelectedProjectManager,
                    RentalTypeId = item.SelectedRentalTypeId
                });
            }

            if (model.SelectedPumpstations != null && model.SelectedPumpstations.Count > 0)
            {
                foreach (var item in model.SelectedPumpstations)
                {
                    if (item.SelectedPumpstationId > 0 && item.PumpAmount > 0)
                    {
                        runningChart.RunningchartPumpstation.Add(new RunningchartPumpstation()
                        {
                            PumpstationId = item.SelectedPumpstationId,
                            Amount = item.PumpAmount
                        });
                    }
                }
            }

            if (model.SelectedLubricants != null && model.SelectedLubricants.Count > 0)
            {
                foreach (var item in model.SelectedLubricants)
                {
                    if (item.SelectedPumpstationId > 0 && item.SelectedLubricantTypeId > 0 && item.PumpAmount > 0)
                    {
                        runningChart.RunningchartLubricants.Add(new RunningchartLubricant()
                        {
                            PumpstationId = item.SelectedPumpstationId,
                            LubricantTypeId = item.SelectedLubricantTypeId,
                            Amount = item.PumpAmount
                        });
                    }
                }
            }

            return runningChart;
        }

        public static List<RunningchartModel> GetRunningchartModelList(List<Runningchart> runningCharts)
        {
            if (runningCharts == null || runningCharts.Count < 0)
                return null;

            var model = from c in runningCharts
                        select new RunningchartModel
                        {
                            RunningchartId = c.Id,
                            BillNumber = c.BillNumber,
                            BillDate = c.BillDate,
                            DriverName = c.DriverName,
                            SelectedVehicleId = c.VehicleId,
                            //SelectedVehicleNo = c.VehicleNumber, //TODO: Remove
                            FuelLeftBegningOfDay = c.FuelLeftBegning,
                            FuelLeftEndOfDay = c.FuelLeftEnd,
                            FuelUsageOfDay = c.FuelUsageOfDay,
                            DailyNote = c.DailyNote,
                            DayStartime = c.DayStartime,
                            DayEndTime = c.DayEndTime,
                            IsApproved = c.IsApproved,
                            ApprovedBy = c.ApprovedBy,
                            EnteredBy = c.EnteredBy,
                        };

            return model.ToList<RunningchartModel>();
        }

        public static RunningchartModel GetRunningchartModel(Runningchart runningChart)
        {
            RunningchartModel model = new RunningchartModel()
            {
                RunningchartId = runningChart.Id,
                BillNumber = runningChart.BillNumber,
                BillDate = runningChart.BillDate,
                DriverName = runningChart.DriverName,
                SelectedVehicleId = runningChart.VehicleId,
                //SelectedVehicleNo = c.VehicleNumber, //TODO: Remove
                FuelLeftBegningOfDay = runningChart.FuelLeftBegning,
                FuelLeftEndOfDay = runningChart.FuelLeftEnd,
                FuelUsageOfDay = runningChart.FuelUsageOfDay,
                DailyNote = runningChart.DailyNote,
                DayStartime = runningChart.DayStartime,
                DayEndTime = runningChart.DayEndTime,
                IsApproved = runningChart.IsApproved,
                ApprovedBy = runningChart.ApprovedBy,
                EnteredBy = runningChart.EnteredBy,
                SelectedChartItems = GetChartItemModelList(runningChart.RunningchartDetails),
                SelectedPumpstations = GetChartPumpstationItemModelList(runningChart.RunningchartPumpstation),
                SelectedLubricants = GetChartLubricantItemModelList(runningChart.RunningchartLubricants),
            };

            return model;
        }

        private static List<ChartItemModel> GetChartItemModelList(List<RunningchartDetails> runningchartDetails)
        {
            var details = from d in runningchartDetails
                          select new ChartItemModel()
                          {
                              StartTime = d.StartTime.ToShortTimeString(),
                              EndTime = d.EndTime.ToShortTimeString(),
                              TimeDifference = d.TimeDifference,
                              StartMeter = d.StartMeter,
                              EndMeter = d.EndMeter,
                              MeterDifference = d.MeterDifference,
                              IdleHours = d.IdleHours,
                              SelectedProjectId = d.ProjectId,
                              SelectedProjectManager = d.ProjectManagerName,
                              SelectedRentalTypeId = d.RentalTypeId
                          };

            return details.ToList<ChartItemModel>();
        }

        private static List<ChartPumpstationItemModel> GetChartPumpstationItemModelList(List<RunningchartPumpstation> runningchartPumps)
        {
            var pumpstations = from item in runningchartPumps
                               select new ChartPumpstationItemModel()
                               {
                                   SelectedPumpstationId = item.PumpstationId,
                                   PumpAmount = item.Amount
                               };

            return pumpstations.ToList<ChartPumpstationItemModel>();
        }

        private static List<ChartLubricantItemModel> GetChartLubricantItemModelList(List<RunningchartLubricant> runningchartLubricant)
        {
            var pumpstations = from item in runningchartLubricant
                               select new ChartLubricantItemModel()
                               {
                                   SelectedPumpstationId = item.PumpstationId,
                                   SelectedLubricantTypeId = item.LubricantTypeId,
                                   PumpAmount = item.Amount
                               };

            return pumpstations.ToList<ChartLubricantItemModel>();
        }

        #endregion

        #region User Mappings

        public static UserModel GetUserModel(Core.User user)
        {
            if (user == null)
                return null;

            return new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                NICNumber = user.NICNumber,
                IsActiveUser = user.IsActiveUser,
                RoleName = user.RoleName,
                Role = (UserRole)user.RoleId,
                DateAdded = user.DateAdded
            };
        }

        public static List<UserModel> GetUserModelList(List<User> users)
        {
            if (users == null)
                return null;

            var userModels = from u in users
                             select new UserModel
                             {
                                 Id = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 UserName = u.UserName,
                                 NICNumber = u.NICNumber,
                                 Role = (UserRole)u.RoleId,
                                 RoleName = u.RoleName,
                                 IsActiveUser = u.IsActiveUser,
                                 DateAdded = u.DateAdded
                             };
            return userModels.ToList<UserModel>();
        }

        public static User GetUser(UserModel model)
        {
            if (model == null)
                return null;

            return new User()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Password = model.Password,
                NICNumber = model.NICNumber,
                IsActiveUser = model.IsActiveUser,
                RoleName = model.RoleName,
                RoleId = (int)model.Role,
                DateAdded = model.DateAdded
            };
        }

        #endregion

        #region Report Mappings

        public static List<FuelConsumptionReportModel> GetFuelConsumptionReportList(List<FuelConsumptionReport> report)
        {
            List<FuelConsumptionReportModel> model = new List<FuelConsumptionReportModel>();
            var vehIds = (from v in report select v.VehicleId).Distinct();
            foreach (var vehicleId in vehIds)
            {
                var recs = report.Where(x => x.VehicleId == vehicleId);
                var first = recs.First();
                FuelConsumptionReportModel m = new FuelConsumptionReportModel()
                {
                    VehicleId = first.VehicleId,
                    VehicleNumber = first.VehicleNumber,
                    IsVehicle = first.IsVehicle,
                    DriverOperatorName = first.DriverOperatorName,
                    VehicleRate = first.VehicleRate,
                    FuelUsageOfVehicle = recs.Sum(x => x.FuelUsageOfDay)
                };
                var totalFuelPumped = recs.Sum(x => x.PumpAmount);
                var totalMeterDiff = recs.Sum(x => x.MeterDifference);
                var actualRate = decimal.Zero;
                if (totalFuelPumped > 0)
                {
                    if (m.IsVehicle)
                    {
                        actualRate = totalMeterDiff / totalFuelPumped;
                    }
                    else
                    {
                        actualRate = totalFuelPumped / totalMeterDiff;
                    }
                }
                //if (totalFuelPumped > 0)
                //    actualRate = totalMeterDiff / totalFuelPumped;

                m.KmHrDone = totalMeterDiff;
                m.TotalFuelUsage = totalFuelPumped;
                m.ActualRate = actualRate;
                model.Add(m);
            }

            return model;
            //var reportModel = from r in report
            //                  select new FuelConsumptionReportModel
            //                  {
            //                      VehicleId = r.VehicleId,
            //                      VehicleNumber = r.VehicleNumber,
            //                      IsVehicle = r.IsVehicle,
            //                      DriverOperatorName = r.DriverOperatorName,
            //                      KmHrDone = r.KmHrDone,
            //                      TotalFuelUsage = r.TotalFuelUsage,
            //                      VehicleRate = r.VehicleRate,
            //                      ActualRate = r.ActualRate
            //                  };
            //return reportModel.ToList<FuelConsumptionReportModel>();
        }

        public static List<HiredVehicleFuelReportModel> GetHiredVehicleFuelReportList(List<HiredVehicleFuelReport> report)
        {
            var reportModel = from r in report
                              select new HiredVehicleFuelReportModel
                              {
                                  VehicleId = r.VehicleId,
                                  VehicleNumber = r.VehicleNumber,
                                  IsVehicle = r.IsVehicle,
                                  DriverOperatorName = r.DriverOperatorName,
                                  OwnerName = r.OwnerName,
                                  KmHrDone = r.KmHrDone,
                                  FuelDrawn = r.FuelDrawn
                              };
            return reportModel.ToList<HiredVehicleFuelReportModel>();
        }

        public static List<DriverOperatorTimeSheetModel> GetDriverOperatorTimeSheetModelList(List<DriverOperatorTimeSheet> report)
        {
            var reportModel = from r in report
                              select new DriverOperatorTimeSheetModel
                              {
                                  RunningchartId = r.RunningchartId,
                                  DriverOperatorName = r.DriverOperatorName,
                                  BillDate = r.BillDate,
                                  VehicleNumber = r.VehicleNumber,
                                  IsVehicle = r.IsVehicle,
                                  InTime = r.InTime,
                                  OutTime = r.OutTime,
                                  WorkDone = r.WorkDone,
                                  OTHours = r.OTHours
                              };
            return reportModel.ToList<DriverOperatorTimeSheetModel>();
        }

        public static List<FuelAndLubricantReportModel> GetFuelAndLubricantReportModelList(List<FuelAndLubricantReport> report)
        {
            var reportModel = from r in report
                              select new FuelAndLubricantReportModel
                              {
                                  RunningchartId = r.RunningchartId,
                                  BillDate = r.BillDate,
                                  VehicleId = r.VehicleId,
                                  VehicleNumber = r.VehicleNumber,
                                  IsVehicle = r.IsVehicle,
                                  DriverOperatorName = r.DriverOperatorName,
                                  IsHiredVehicle = r.IsHiredVehicle,
                                  FuelType = r.FuelType,
                                  FuelQty = r.FuelQty,
                                  FuelRate = r.FuelRate,
                                  LubricantType = r.LubricantType,
                                  LubricantQty = r.LubricantQty,
                                  LubricantRate = r.LubricantRate
                              };
            return reportModel.ToList<FuelAndLubricantReportModel>();
        }

        public static List<VehicleMachineRegisterModel> GetVehicleMachineRegisterModelList(List<VehicleMachineRegister> report)
        {
            var reportModel = from r in report
                              select new VehicleMachineRegisterModel
                              {
                                  VehicleId = r.VehicleId,
                                  VehicleNumber = r.VehicleNumber,
                                  CompanyCode = r.CompanyCode,
                                  VehicleType = r.VehicleType,
                                  VehicleLocation = r.VehicleLocation
                              };
            return reportModel.ToList<VehicleMachineRegisterModel>();
        }

        public static List<HireBillReportModel> GetHireBillReportModelList(List<HireBillReport> report)
        {
            var reportModel = from r in report
                              select new HireBillReportModel
                              {
                                  RunningchartId = r.RunningchartId,
                                  BillDate = r.BillDate,
                                  VehicleNumber = r.VehicleNumber,
                                  CompanyCode = r.CompanyCode,
                                  VehicleHireRate = r.VehicleHireRate,
                                  IsVehicle = r.IsVehicle,
                                  KmHrDone = r.KmHrDone,
                                  Amount = r.Amount
                              };
            return reportModel.ToList<HireBillReportModel>();
        }

        public static HireBillPrivateReportModel GetHireBillPrivateReportModelList(HireBillPrivateReport report)
        {
            HireBillPrivateReportModel model = new HireBillPrivateReportModel()
            {
                HireBillPrivateReportDetails = new List<HireBillPrivateReportDetailsModel>(),
                HireBillPrivateReportFuel = new List<HireBillPrivateReportPumpstationModel>(),
                HireBillPrivateReportLubricants = new List<HireBillPrivateReportLubricantModel>()
            };

            foreach (var item in report.HireBillPrivateReportDetails)
            {
                model.HireBillPrivateReportDetails.Add(new HireBillPrivateReportDetailsModel()
                {
                    RunningchartId = item.Id,
                    BillDate = item.BillDate,
                    ProjectLocation = item.ProjectLocation,
                    FuelUsageOfDay = item.FuelUsageOfDay,
                    KmHrDone = item.KmHrDone,
                    HireAmount = item.HireAmount,
                    VehicleRate = item.VehicleRate
                });
            }

            foreach (var item in report.HireBillPrivateReportPumpstations)
            {
                model.HireBillPrivateReportFuel.Add(new HireBillPrivateReportPumpstationModel()
                {
                    Id = item.Id,
                    RunningchartId = item.RunningchartId,
                    BillDate = item.BillDate,
                    VehicleId = item.VehicleId,
                    Amount = item.Amount,
                    FuelRate = item.FuelRate,
                    PumpstationId = item.PumpstationId,
                    PumpstationName = item.PumpstationName
                });
            }

            foreach (var item in report.HireBillPrivateReportLubricants)
            {
                model.HireBillPrivateReportLubricants.Add(new HireBillPrivateReportLubricantModel()
                {
                    Id = item.Id,
                    RunningchartId = item.RunningchartId,
                    BillDate = item.BillDate,
                    VehicleId = item.VehicleId,
                    Amount = item.Amount,
                    LubricantTypeId = item.LubricantTypeId,
                    LubricantType = item.LubricantType,
                    LubricantRate = item.LubricantRate,
                    PumpstationId = item.PumpstationId,
                    PumpstationName = item.PumpstationName
                });
            }

            return model;
        }

        public static List<WorkDoneReportModel> GetWorkDoneReportModelList(List<WorkDoneReport> report)
        {
            var reportModel = from r in report
                              select new WorkDoneReportModel
                              {
                                  RunningchartId = r.RunningchartId,
                                  BillDate = r.BillDate,
                                  DriverName = r.DriverName,
                                  WorkDone = r.WorkDone,
                                  FuelUsageOfDay = r.FuelUsageOfDay,
                                  ProjectLocation = r.ProjectLocation
                              };
            return reportModel.ToList<WorkDoneReportModel>();
        }

        public static IEnumerable<SelectListItem> GetPumpstationOptions(List<PumpstationModel> pumpstationsList)
        {
            List<SelectListItem> options = new List<SelectListItem>(pumpstationsList.Count + 1)
            {
                new SelectListItem(){ Text = "- SELECT -", Value = "0", Selected = true }
            };
            var pumpstations = from p in pumpstationsList
                               select new SelectListItem
                               {
                                   Text = p.PumpStationName,
                                   Value = p.Id.ToString()
                               };

            return options.Concat(pumpstations.ToList());
        }

        public static IEnumerable<SelectListItem> GetProjectOptions(List<ProjectModel> projectsList)
        {
            List<SelectListItem> options = new List<SelectListItem>(projectsList.Count + 1)
            {
                new SelectListItem(){ Text = "- SELECT -", Value = "0", Selected = true }
            };
            var projects = from p in projectsList
                               select new SelectListItem
                               {
                                   Text = p.ProjectName,
                                   Value = p.Id.ToString()
                               };

            return options.Concat(projects.ToList());
        }

        public static IEnumerable<SelectListItem> GetVehicleOptions(List<VehicleModel> vehicleList)
        {
            List<SelectListItem> options = new List<SelectListItem>(vehicleList.Count + 1)
            {
                new SelectListItem(){ Text = "- SELECT -", Value = "0", Selected = true }
            };
            var projects = from v in vehicleList
                           select new SelectListItem
                           {
                               Text = v.VehicleNumber,
                               Value = v.Id.ToString()
                           };

            return options.Concat(projects.ToList().OrderBy(x => x.Text));
        }

        public static IEnumerable<SelectListItem> GetCompanyCodeOptions(List<VehicleModel> vehicleList)
        {
            List<SelectListItem> options = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "- SELECT -", Value = "0", Selected = true },
                new SelectListItem(){ Text = "- N/A -", Value = "-1" }
            };
            var codes = from v in vehicleList
                           select new SelectListItem
                           {
                               Text = v.CompanyCode,
                               Value = v.Id.ToString()
                           };

            return options.Concat(codes.ToList().Where(x => !string.Equals(x.Text.ToLower(), "no")).OrderBy(x => x.Text));
        }

        #endregion
    }
}