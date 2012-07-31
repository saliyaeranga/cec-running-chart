using System;
using System.Data;
using CECRunningChart.Core;

namespace CECRunningChart.Data.Pumpstation
{
    public class PumpstationDataProvider : BaseDataProvider, IPumpstationDataProvider
    {
        #region IPumpstationDataProvider Members

        public bool AddNewPumpstation(PumpStation pumpstation)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@PumpstationName", pumpstation.PumpStationName);
                parameters.Add("@Description", pumpstation.Description);
                ExecuteNoneQuery("proc_AddNewPumpstation", parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePumpstation(PumpStation pumpstation)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@PumpstationId", pumpstation.Id);
                parameters.Add("@PumpstationName", pumpstation.PumpStationName);
                parameters.Add("@Description", pumpstation.Description);
                ExecuteNoneQuery("proc_UpdatePumpstation", parameters);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetAllPumpstations()
        {
            try
            {
                return ExecuteDataSet("proc_GetAllPumpstations", null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetPumpstation(int id)
        {
            try
            {
                Parameters parameters = new Parameters();
                parameters.Add("@PumpstationId", id);
                return ExecuteDataSet("proc_GetPumpstationById", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
