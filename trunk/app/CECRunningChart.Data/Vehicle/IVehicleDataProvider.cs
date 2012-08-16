using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CECRunningChart.Data.Vehicle
{
    public interface IVehicleDataProvider
    {
        bool AddNewVehicle(CECRunningChart.Core.Vehicle vehicle);
        bool UpdateVehicle(CECRunningChart.Core.Vehicle vehicle);
        bool DeleteVehicle(int id);
        DataSet GetAllVehicles();
        DataSet GetVehicle(int id);
        DataSet GetAllFuelTypes();
        DataSet GetAllLubricantTypes();
        DataSet GetFuelType(int id);
        DataSet GetLubricantType(int id);
        bool UpdateFuelType(Core.FuelType fuelType);
        bool UpdateLubricantType(Core.LubricantType lubricantType);
        DataSet GetAllVehicleTypes();
        DataSet GetVehicleType(int id);
        bool AddNewLubricantType(CECRunningChart.Core.LubricantType lubricantType);
        bool AddNewFuelType(CECRunningChart.Core.FuelType fuelType);
    }
}
