using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CECRunningChart.Data.Vehicle
{
    public class VehicleDataProvider : BaseDataProvider, IVehicleDataProvider
    {
        #region IVehicleDataProvider Members

        public bool AddNewVehicle(Core.Vehicle vehicle)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@VehicleNo", vehicle.VehicleNumber);
                parameters.Add("@Type", vehicle.VehicleTypeId);
                parameters.Add("@Description", vehicle.Description);
                ExecuteNoneQuery("proc_AddNewVehicle", parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateVehicle(Core.Vehicle vehicle)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@VehicleId", vehicle.Id);
                parameters.Add("@VehicleNo", vehicle.VehicleNumber);
                parameters.Add("@Type", vehicle.VehicleTypeId);
                parameters.Add("@Description", vehicle.Description);
                parameters.Add("@Status", vehicle.Status);
                ExecuteNoneQuery("proc_UpdateVehicle", parameters);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteVehicle(int id)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@VehicleId", id);
                ExecuteNoneQuery("proc_DeleteVehicle", parameters);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetAllVehicles()
        {
            try
            {
                return ExecuteDataSet("proc_GetAllVehicles", null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetVehicle(int id)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@VehicleId", id);
                return ExecuteDataSet("proc_GetVehicleById", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetAllFuelTypes()
        {
            return ExecuteDataSet("proc_GetAllFuelTypes", null);
        }

        public DataSet GetAllLubricantTypes()
        {
            return ExecuteDataSet("proc_GetAllLubricantTypes", null);
        }

        public DataSet GetFuelType(int id)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("FuelTypeId", id);
                return ExecuteDataSet("proc_GetFuelTypeById", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetLubricantType(int id)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@LubricantTypeId", id);
                return ExecuteDataSet("proc_GetLubricantTypeById", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateFuelType(Core.FuelType fuelType)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@FuelTypeId", fuelType.Id);
                parameters.Add("@NewRate", fuelType.FuelRate);
                ExecuteNoneQuery("proc_UpdateFuelCost", parameters);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateLubricantType(Core.LubricantType lubricantType)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@LubricantTypeId", lubricantType.Id);
                parameters.Add("@NewRate", lubricantType.LubricantRate);
                ExecuteNoneQuery("proc_UpdateLubricantCost", parameters);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
