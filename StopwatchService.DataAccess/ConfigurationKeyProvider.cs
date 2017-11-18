using Microsoft.Azure;

namespace StopwatchService.DataAccess
{
    public class ConfigurationKeyProvider
    {
      
        public static string GetConfiguration(string key)
        {
            return CloudConfigurationManager.GetSetting(key);
        }
    }
}
