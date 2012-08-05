using System.Data;
using CECRunningChart.Core;

namespace CECRunningChart.Data.Pumpstation
{
    public interface IPumpstationDataProvider
    {
        bool AddNewPumpstation(PumpStation pumpstation);
        bool UpdatePumpstation(PumpStation pumpstation);
        DataSet GetAllPumpstations();
        DataSet GetPumpstation(int id);
    }
}
