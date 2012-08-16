using System;
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
                parameters.Add("@CompanyCode", vehicle.CompanyCode);
                parameters.Add("@VehicleTypeId", vehicle.VehicleTypeId);
                parameters.Add("@Description", vehicle.Description);
                parameters.Add("@DriverName", vehicle.DriverOperatorName);
                parameters.Add("@FuelUsage", vehicle.FuelUsage);
                parameters.Add("@FuelTypeId", vehicle.FuelType);
                parameters.Add("@LubricantTypeId", vehicle.LubricantType);
                parameters.Add("@IsHiredVehicle", vehicle.IsHiredVehicle);
                parameters.Add("@HireRate", vehicle.HireRate);
                parameters.Add("@OwnerName", vehicle.OwnerName);
                parameters.Add("@IsVehicle", vehicle.IsVehicle);
                parameters.Add("@Status", vehicle.Status);
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
                parameters.Add("@CompanyCode", vehicle.CompanyCode);
                parameters.Add("@VehicleTypeId", vehicle.VehicleTypeId);
                parameters.Add("@Description", vehicle.Description);
                parameters.Add("@DriverName", vehicle.DriverOperatorName);
                parameters.Add("@FuelUsage", vehicle.FuelUsage);
                parameters.Add("@FuelTypeId", vehicle.FuelType);
                parameters.Add("@LubricantTypeId", vehicle.LubricantType);
                parameters.Add("@IsHiredVehicle", vehicle.IsHiredVehicle);
                parameters.Add("@HireRate", vehicle.HireRate);
                parameters.Add("@OwnerName", vehicle.OwnerName);
                parameters.Add("@IsVehicle", vehicle.IsVehicle);
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

        public DataSet GetAllVehicleTypes()
        {
            return ExecuteDataSet("proc_GetAllVehicleTypes", null);
        }

        public DataSet GetVehicleType(int id)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@VehicleTypeId", id);
                return ExecuteDataSet("proc_GetVehicleTypeById", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddNewLubricantType(CECRunningChart.Core.LubricantType lubricantType)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@LubricantType", lubricantType.LubricantName);
                parameters.Add("@Rate", lubricantType.LubricantRate);
                ExecuteNoneQuery("proc_AddNewLubricantType", parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddNewFuelType(CECRunningChart.Core.FuelType fuelType)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@FuelName", fuelType.FuelName);
                parameters.Add("@Rate", fuelType.FuelRate);
                ExecuteNoneQuery("proc_AddNewFuelType", parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        #endregion
    }
}
