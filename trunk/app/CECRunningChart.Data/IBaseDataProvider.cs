using System.Collections.Generic;
using System.Data;

namespace CECRunningChart.Data
{
    public interface IBaseDataProvider
    {
        IDataReader ExecuteReader(string procedureName, Parameters parameters);
        DataSet ExecuteDataSet(string procedureName, Parameters parameters);

        void ExecuteNoneQuery(string procedureName, Parameters parameters);
        Dictionary<string, object> ExecuteNoneQueryWithOutputParams(string procedureName, Parameters parameters);

        int ExecuteScalar(string procedureName, Parameters parameters);
    }
}
