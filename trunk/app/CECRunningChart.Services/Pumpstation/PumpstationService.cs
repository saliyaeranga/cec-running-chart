using System.Collections.Generic;
using System.Data;
using CECRunningChart.Core;
using CECRunningChart.Data.Pumpstation;

namespace CECRunningChart.Services.Pumpstation
{
    public class PumpstationService : IPumpstationService
    {
        #region Private Members

        private readonly IPumpstationDataProvider dataProvider;

        #endregion

        #region Constructor

        public PumpstationService()
        {
            dataProvider = new PumpstationDataProvider();
        }

        #endregion

        #region IPumpstationService Members

        public bool AddNewPumpstation(PumpStation pumpStation)
        {
            return dataProvider.AddNewPumpstation(pumpStation);
        }

        public bool UpdatePumpstation(PumpStation pumpStation)
        {
            return dataProvider.UpdatePumpstation(pumpStation);
        }

        public List<PumpStation> GetAllPumpstations()
        {
            DataSet pumpDataSet = dataProvider.GetAllPumpstations();
            return ConversionHelper.ConvertToList<PumpStation>(pumpDataSet);
        }

        public PumpStation GetPumpstation(int id)
        {
            DataSet pumpDataSet = dataProvider.GetPumpstation(id);
            return ConversionHelper.ConvertToObject<PumpStation>(pumpDataSet.Tables[0].Rows[0]);
        }

        #endregion
    }
}
