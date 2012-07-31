using System.Linq;
using System.Web.Mvc;
using CECRunningChart.Core;
using CECRunningChart.Services.Pumpstation;
using CECRunningChart.Web.Models.Pumpstation;

namespace CECRunningChart.Web.Controllers
{
    public class PumpstationController : Controller
    {
        #region Private Members

        private IPumpstationService pumpstationService;

        #endregion

        #region Constructor

        public PumpstationController()
        {
            pumpstationService = new PumpstationService();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public ActionResult Index()
        {
            var pumpStations = pumpstationService.GetAllPumpstations();
            var pumpStationList = from p in pumpStations
                                  select new PumpstationModel
                                  {
                                      Id = p.Id,
                                      PumpStationName = p.PumpStationName,
                                      Description = p.Description
                                  };
            var model = pumpStationList.ToList<PumpstationModel>();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            PumpstationModel model = GetPumpstationModelById(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(PumpstationModel model)
        {
            try
            {
                var pumpStation = GetPumpStationForModel(model);
                pumpstationService.AddNewPumpstation(pumpStation);
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
            PumpstationModel model = GetPumpstationModelById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, PumpstationModel model)
        {
            try
            {
                var pumpStation = GetPumpStationForModel(model);
                pumpstationService.UpdatePumpstation(pumpStation);
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
            PumpstationModel model = GetPumpstationModelById(id);
            return View(model);
        }

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

        #endregion

        #region Private Methods

        private PumpstationModel GetPumpstationModelById(int id)
        {
            PumpStation pumpStation = pumpstationService.GetPumpstation(id);
            return new PumpstationModel()
            {
                Id = pumpStation.Id,
                PumpStationName = pumpStation.PumpStationName,
                Description = pumpStation.Description
            };
        }

        private PumpStation GetPumpStationForModel(PumpstationModel model)
        {
            return new PumpStation()
            {
                Id = model.Id,
                PumpStationName = model.PumpStationName,
                Description = model.Description
            };
        }

        #endregion
    }
}
