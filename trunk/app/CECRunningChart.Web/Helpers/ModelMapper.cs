using System;
using System.Collections.Generic;
using System.Linq;
using CECRunningChart.Common;
using CECRunningChart.Core;
using CECRunningChart.Web.Models.Project;
using CECRunningChart.Web.Models.Pumpstation;
using CECRunningChart.Web.Models.Runningchart;
using CECRunningChart.Web.Models.User;
using CECRunningChart.Web.Models.Vehicle;
using CECRunningChart.Web.Models.Reports;

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
                RunningchartPumpstation = new List<RunningchartPumpstation>()
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
                    ProjectId = item.SelectedProjectId,
                    ProjectManagerName = item.SelectedProjectManager
                });
            }

            foreach (var item in model.SelectedPumpstations)
            {
                runningChart.RunningchartPumpstation.Add(new RunningchartPumpstation()
                {
                    PumpstationId = item.SelectedPumpstationId,
                    Amount = item.PumpAmount
                });
            }

            return runningChart;
        }

        public static List<RunningchartModel> GetRunningchartModel(List<Runningchart> runningCharts)
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
            var reportModel = from r in report
                              select new FuelConsumptionReportModel
                              {
                                  VehicleId = r.VehicleId,
                                  VehicleNumber = r.VehicleNumber,
                                  IsVehicle = r.IsVehicle,
                                  DriverOperatorName = r.DriverOperatorName,
                                  KmHrDone = r.KmHrDone,
                                  TotalFuelUsage = r.TotalFuelUsage,
                                  VehicleRate = r.VehicleRate,
                                  ActualRate = r.ActualRate
                              };
            return reportModel.ToList<FuelConsumptionReportModel>();
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

        #endregion
    }
}