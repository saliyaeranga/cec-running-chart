﻿using System.Collections.Generic;

namespace CECRunningChart.Services.Vehicle
{
    public interface IVehicleService
    {
        bool AddNewVehicle(Core.Vehicle vehicle);
        bool UpdateVehicle(Core.Vehicle vehicle);
        bool DeleteVehicle(int id);
        List<Core.Vehicle> GetAllVehicles();
        Core.Vehicle GetVehicle(int id);
        List<Core.FuelType> GetAllFuelTypes();
        List<Core.LubricantType> GetAllLubricantTypes();
        Core.FuelType GetFuelType(int id);
        Core.LubricantType GetLubricantType(int id);
        bool UpdateFuelType(Core.FuelType fuelType);
        bool UpdateLubricantType(Core.LubricantType lubricantType);
        List<Core.VehicleType> GetAllVehicleTypes();
        Core.VehicleType GetVehicleType(int id);
        bool AddNewLubricantType(CECRunningChart.Core.LubricantType lubricantType);
        bool AddNewFuelType(CECRunningChart.Core.FuelType fuelType);
        List<Core.Vehicle> GetAllHiredVehicles();
    }
}
