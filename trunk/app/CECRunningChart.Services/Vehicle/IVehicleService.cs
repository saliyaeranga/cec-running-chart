using System.Collections.Generic;

namespace CECRunningChart.Services.Vehicle
{
    public interface IVehicleService
    {
        bool AddNewVehicle(CECRunningChart.Core.Vehicle vehicle);
        bool UpdateVehicle(CECRunningChart.Core.Vehicle vehicle);
        bool DeleteVehicle(int id);
        List<CECRunningChart.Core.Vehicle> GetAllVehicles();
        CECRunningChart.Core.Vehicle GetVehicle(int id);
    }
}
