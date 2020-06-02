using System.Configuration;

namespace CanteenMenuInterface.Helpers
{
    public static class ConnectionStringHelper
    {
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
