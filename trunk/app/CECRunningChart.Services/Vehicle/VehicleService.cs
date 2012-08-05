using System.Collections.Generic;
using System.Data;
using CECRunningChart.Data.Vehicle;

namespace CECRunningChart.Services.Vehicle
{
    public class VehicleService : IVehicleService
    {
        #region Private Members

        private IVehicleDataProvider dataProvider;

        #endregion

        #region Constructor

        public VehicleService()
        {
            dataProvider = new VehicleDataProvider();
        }

        #endregion

        #region IVehicleService Members

        public bool AddNewVehicle(Core.Vehicle vehicle)
        {
            return dataProvider.AddNewVehicle(vehicle);
        }

        public bool UpdateVehicle(Core.Vehicle vehicle)
        {
            return dataProvider.UpdateVehicle(vehicle);
        }

        public bool DeleteVehicle(int id)
        {
            return dataProvider.DeleteVehicle(id);
        }

        public List<Core.Vehicle> GetAllVehicles()
        {
            DataSet vehicleDataSet = dataProvider.GetAllVehicles();
            return ConversionHelper.ConvertToList<Core.Vehicle>(vehicleDataSet);
        }

        public Core.Vehicle GetVehicle(int id)
        {
            DataSet vehicleDataSet = dataProvider.GetVehicle(id);
            return ConversionHelper.ConvertToObject<Core.Vehicle>(vehicleDataSet.Tables[0].Rows[0]);
        }

        public List<Core.FuelType> GetAllFuelTypes()
        {
            DataSet fuelDataSet = dataProvider.GetAllFuelTypes();
            return ConversionHelper.ConvertToList<Core.FuelType>(fuelDataSet);
        }

        public List<Core.LubricantType> GetAllLubricantTypes()
        {
            DataSet lubricantSet = dataProvider.GetAllLubricantTypes();
            return ConversionHelper.ConvertToList<Core.LubricantType>(lubricantSet);
        }

        public Core.FuelType GetFuelType(int id)
        {
            DataSet fuelType = dataProvider.GetFuelType(id);
            return ConversionHelper.ConvertToObject<Core.FuelType>(fuelType.Tables[0].Rows[0]);
        }

        public Core.LubricantType GetLubricantType(int id)
        {
            DataSet lubricant = dataProvider.GetLubricantType(id);
            return ConversionHelper.ConvertToObject<Core.LubricantType>(lubricant.Tables[0].Rows[0]);
        }

        public bool UpdateFuelType(Core.FuelType fuelType)
        {
            return dataProvider.UpdateFuelType(fuelType);
        }

        public bool UpdateLubricantType(Core.LubricantType lubricantType)
        {
            return dataProvider.UpdateLubricantType(lubricantType);
        }

        #endregion
    }
}
