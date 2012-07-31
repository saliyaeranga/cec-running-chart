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

        #endregion
    }
}
