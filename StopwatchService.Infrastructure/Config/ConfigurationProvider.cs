using System.Configuration;

namespace StopwatchService.Infrasctructure.Config
{
    public class ConfigurationProvider
    {
        public static string GetConfiguration(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}