using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CECRunningChart.Core;
using CECRunningChart.Web.Models.Pumpstation;
using CECRunningChart.Web.Models.Vehicle;
using CECRunningChart.Web.Models.Project;
using CECRunningChart.Web.Models.Runningchart;
using CECRunningChart.Web.Models.User;
using CECRunningChart.Common;

namespace CECRunningChart.Web.Helpers
{
    public static class ModelMapper
    {
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

        public static List<ProjectModel> GetProjectModelList(IEnumerable<Project> projects)
        {
            var projectsList = from p in projects
                               select new ProjectModel
                               {
                                   Id = p.Id,
                                   ProjectName = p.ProjectName,
                                   ProjectDescription = p.ProjectDescription,
                                   ProjectManager = p.ProjectManager,
                                   IsActiveProject = !p.IsActiveProject
                               };
            return projectsList.ToList<ProjectModel>();
        }

        #region Vehicle Mappings

        public static List<VehicleModel> GetVehicleModelList(IEnumerable<Vehicle> vehicles)
        {
            var vehicleList = from v in vehicles
                              select new VehicleModel
                              {
                                  Id = v.Id,
                                  VehicleNumber = v.VehicleNumber,
                                  VehicleType = v.VehicleType,
                                  Description = v.Description
                              };
            return vehicleList.ToList<VehicleModel>();
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
                RunningchartDetails = new List<RunningchartDetails>(),
                RunningchartPumpstation = new List<RunningchartPumpstation>()
            };

            foreach (var item in model.SelectedChartItems)
            {
                var startTimePart = Convert.ToDateTime(item.StartTime);
                var endTimePart = Convert.ToDateTime(item.EndTime);
                DateTime startTime = new DateTime(model.BillDate.Year, model.BillDate.Month, model.BillDate.Day, 
                    startTimePart.Hour, startTimePart.Minute, startTimePart.Second);
                DateTime endTime = new DateTime(model.BillDate.Year, model.BillDate.Month, model.BillDate.Day, 
                    endTimePart.Hour, endTimePart.Minute, endTimePart.Second);

                runningChart.RunningchartDetails.Add(new RunningchartDetails()
                {
                    StartTime = startTime,
                    EndTime = endTime,
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
                            SelectedVehicleNo = c.VehicleNumber,
                            FuelLeftBegningOfDay = c.FuelLeftBegning,
                            FuelLeftEndOfDay = c.FuelLeftEnd,
                            FuelUsageOfDay = c.FuelUsageOfDay,
                            DailyNote = c.DailyNote
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
    }
}