using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CECRunningChart.Core;
using CECRunningChart.Services.Vehicle;
using CECRunningChart.Web.Common;
using CECRunningChart.Web.Helpers;
using CECRunningChart.Web.Models.Vehicle;

namespace CECRunningChart.Web.Controllers
{
    [Authorize]
    [CECAuthorize(Roles = "Admin")]
    public class VehicleController : Controller
    {
        #region Private Members

        private readonly IVehicleService vehicleService;

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
                List<VehicleModel> model = ModelMapper.GetVehicleModelList(vehicles);
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
                var vehicle = vehicleService.GetVehicle(id);
                VehicleModel model = ModelMapper.GetVehicleModel(vehicle);
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
            var vehicleModel = new VehicleModel();
            PopulateVehicleModel(vehicleModel);
            return View(vehicleModel);
        } 

        [HttpPost]
        public ActionResult Create(VehicleModel model)
        {
            if (!ModelState.IsValid)
            {
                PopulateVehicleModel(model);
                return View(model);
            }

            try
            {
                var vehicle = ModelMapper.GetVehicle(model);
                vehicleService.AddNewVehicle(vehicle);
                return RedirectToAction("Index");
            }
            catch
            {
                PopulateVehicleModel(model);
                return View(model);
            }
        }
 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                Vehicle vehicle = vehicleService.GetVehicle(id);
                VehicleModel model = ModelMapper.GetVehicleModel(vehicle);
                PopulateVehicleModel(model);
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
            if (!ModelState.IsValid)
            {
                PopulateVehicleModel(model);
                return View(model);
            }

            try
            {
                var vehicle = ModelMapper.GetVehicle(model);
                vehicleService.UpdateVehicle(vehicle);
                return RedirectToAction("Index");
            }
            catch
            {
                PopulateVehicleModel(model);
                return View(model);
            }
        }

        /*
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Vehicle vehicle = vehicleService.GetVehicle(id);
                VehicleModel model = ModelMapper.GetVehicleModel(vehicle);
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
        */

        [HttpGet]
        public ActionResult Fuel()
        {
            try
            {
                var fuelList = vehicleService.GetAllFuelTypes();
                List<FuelModel> model = ModelMapper.GetFuelModelList(fuelList);
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult EditFuel(int id)
        {
            try
            {
                var fuel = vehicleService.GetFuelType(id);
                FuelModel model = ModelMapper.GetFuelModel(fuel);
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditFuel(FuelModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var fuel = ModelMapper.GetFuel(model);
                vehicleService.UpdateFuelType(fuel);
                return RedirectToAction("Fuel");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Lubricant()
        {
            try
            {
                var lubricantList = vehicleService.GetAllLubricantTypes();
                List<LubricantModel> model = ModelMapper.GetLubricantModelList(lubricantList);
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult EditLubricant(int id)
        {
            try
            {
                var lubricant = vehicleService.GetLubricantType(id);
                LubricantModel model = ModelMapper.GetLubricantModel(lubricant);
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditLubricant(LubricantModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var lubricant = ModelMapper.GetLubricant(model);
                vehicleService.UpdateLubricantType(lubricant);
                return RedirectToAction("Lubricant");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Members

        private VehicleModel PopulateVehicleModel(VehicleModel model)
        {
            var fuelTypes = vehicleService.GetAllFuelTypes();
            var lubricantTypes = vehicleService.GetAllLubricantTypes();
            var vehicleTypes = vehicleService.GetAllVehicleTypes();
            model.AvailableFuel = ModelMapper.GetFuelModelList(fuelTypes);
            model.AvailableLubricants = ModelMapper.GetLubricantModelList(lubricantTypes);
            model.AvailableVehicleTypes = ModelMapper.GetVehicleTypeModelList(vehicleTypes);
            return model;
        }

        #endregion
    }
}
