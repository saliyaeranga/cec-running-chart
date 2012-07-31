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
    }
}
