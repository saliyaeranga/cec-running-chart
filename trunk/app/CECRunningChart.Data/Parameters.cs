using System.Collections.Generic;
using System.Data;

namespace CECRunningChart.Data
{
    public class Parameters : List<Parameter>
    {
        #region Public Methods

        public void Add(string key, object value)
        {
            Add(new Parameter(key, value));
        }

        public void Add(string key, object value, ParameterDirection parameterDirection)
        {
            Add(new Parameter(key, value, parameterDirection));
        }

        #endregion
    }
}
