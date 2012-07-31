using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CECRunningChart.Core;

namespace CECRunningChart.Services.Pumpstation
{
    public interface IPumpstationService
    {
        bool AddNewPumpstation(PumpStation pumpStation);
        bool UpdatePumpstation(PumpStation pumpStation);
        List<PumpStation> GetAllPumpstations();
        PumpStation GetPumpstation(int id);
    }
}
