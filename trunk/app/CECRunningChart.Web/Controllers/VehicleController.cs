using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CECRunningChart.Services.Vehicle;
using CECRunningChart.Web.Models.Vehicle;
using CECRunningChart.Core;
using CECRunningChart.Web.Common;

namespace CECRunningChart.Web.Controllers
{
    [Authorize]
    [CECAuthorize(Roles = "Admin")]
    public class VehicleController : Controller
    {
        #region Private Members

        private IVehicleService vehicleService;

        #endregion

        #region Constructor

        public VehicleController()
        {
            vehicleService = new VehicleService();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var vehicles = vehicleService.GetAllVehicles();
                var vehiclesList = from v in vehicles
                                      select new VehicleModel
                                      {
                                          Id = v.Id,
                                          VehicleNumber = v.VehicleNumber,
                                          VehicleType = v.VehicleType,
                                          Description = v.Description
                                      };
                var model = vehiclesList.ToList<VehicleModel>();
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                VehicleModel model = GetVehicleModelById(id);
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(VehicleModel model)
        {
            try
            {
                var vehicle = GetVehicleForModel(model);
                vehicleService.AddNewVehicle(vehicle);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                VehicleModel model = GetVehicleModelById(id);
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, VehicleModel model)
        {
            try
            {
                var vehicle = GetVehicleForModel(model);
                vehicleService.UpdateVehicle(vehicle);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                VehicleModel model = GetVehicleModelById(id);
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, string temp)
        {
            try
            {
                vehicleService.DeleteVehicle(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Private Members

        private VehicleModel GetVehicleModelById(int id)
        {
            Vehicle vehicle = vehicleService.GetVehicle(id);
            return new VehicleModel()
            {
                Id = vehicle.Id,
                VehicleNumber = vehicle.VehicleNumber,
                VehicleType = vehicle.VehicleType,
                Description = vehicle.Description,
                Status = vehicle.Status
            };
        }

        private Vehicle GetVehicleForModel(VehicleModel model)
        {
            return new Vehicle()
            {
                Id = model.Id,
                VehicleNumber = model.VehicleNumber,
                VehicleType = model.VehicleType,
                Description = model.Description,
                Status = model.Status
            };
        }

        #endregion
    }
}
