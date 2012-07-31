using System.Configuration;

namespace CECRunningChart.Data
{
    public static class DataSource
    {
        public const string CONN_ST_KEY = "CECRunningChartConnection";

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[CONN_ST_KEY].ConnectionString;
            }
        }

        public static string ProviderName
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[CONN_ST_KEY].ProviderName;
            }
        }
    }
}
